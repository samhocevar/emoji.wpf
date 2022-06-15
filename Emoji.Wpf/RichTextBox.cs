//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using Emoji.Wpf.BBCode;
using Stfu.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
#if DEBUG
using System.Text.RegularExpressions;
#endif
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
#if DEBUG
using System.Windows.Markup;
#endif
using System.Windows.Media;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    public sealed class TextSelection : TextRange
    {
        internal TextSelection(TextPointer start, TextPointer end)
          : base(start, end) { }

        /// <summary>
        /// Override selection to text conversion in order to convert back all
        /// EmojiInline instances to their equivalent UTF-8 sequences.
        /// </summary>
        public new string Text
        {
            get
            {
                var buf = new StringBuilder();

                for (TextPointer p = Start, next = null;
                     p != null && p.CompareTo(End) < 0;
                     p = next)
                {
                    next = p.GetNextContextPosition(LogicalDirection.Forward);
                    if (next == null)
                        break;

                    switch (p.GetPointerContext(LogicalDirection.Forward))
                    {
                        case TextPointerContext.ElementStart:
                            if (p.GetAdjacentElement(LogicalDirection.Forward) is EmojiInline emoji)
                                buf.Append(emoji.Text);
                            break;
                        case TextPointerContext.ElementEnd:
                        case TextPointerContext.EmbeddedElement:
                            break;
                        case TextPointerContext.Text:
                            // Get text from the Run but don’t go past end
                            buf.Append(new TextRange(p, next.CompareTo(End) < 0 ? next : End).Text);
                            break;
                    }
                }

                return buf.ToString();
            }
        }
    }

    public enum BBCodeVisibility
    {
        Visible,
        Hidden,
        OnCaretInside
    }

    public class RichTextBox : Controls.RichTextBox, IEmojiControl
    {
        public RichTextBox()
        {
            CommandManager.AddPreviewExecutedHandler(this, PreviewExecuted);
            CommandManager.AddPreviewCanExecuteHandler(this, PreviewCanExecuteHandler);
            SetValue(Block.LineHeightProperty, 1.0);
            Selection = new TextSelection(Document.ContentStart, Document.ContentStart);
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
        }

        protected override void OnSelectionChanged(RoutedEventArgs e)
        {
            base.OnSelectionChanged(e);
            if (m_override_selection != null)
            {
                var tmp = m_override_selection; // Prevent infinite recursion
                m_override_selection = null;
                base.Selection.Select(tmp.Start, tmp.End);
            }
            Selection = new TextSelection(base.Selection.Start, base.Selection.End);

            if (!m_pending_change)
                UpdateBBCodeMarkupsVisibility();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // If the user clicked on an emoji, remember where it was. The default RichTextBox
            // behaviour is to select the whole InlineUIContainer instead of positioning the
            // caret, so in the case of a single click we want to cancel that.
            var hit = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (hit.VisualHit is Controls.Image im && im.Parent is EmojiInline emoji)
            {
                // Single click: cancel selection and position caret instead.
                // Double click: select a single emoji glyph
                // Triple click: default RichTextBox behaviour (select all)
                if (e.ClickCount == 1)
                {
                    var caret = e.GetPosition(im).X < im.ActualWidth / 2
                              ? emoji.ContentStart : emoji.ContentEnd;
                    m_override_selection = new TextSelection(caret, caret);
                }
                else if (e.ClickCount == 2)
                    m_override_selection = new TextSelection(emoji.ContentStart, emoji.ContentEnd);
                else
                    m_override_selection = null;
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Handle preview drag event in order to override the serialized data. By default WPF will not
        /// serialize embedded elements unless they are images (see [1]), so all our emojis get replaced
        /// with " ". To avoid this problem we get rid of the XAML and RTF serialisations and replace the
        /// dragged text with the current selection.
        /// [1] https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/windows/Documents/TextRangeSerialization.cs,1180
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewDragEnter(DragEventArgs e)
        {
            if (e.Source == Document)
            {
                foreach (var fmt in new string[] { DataFormats.Rtf, DataFormats.Xaml, DataFormats.XamlPackage })
                    if (e.Data.GetDataPresent(fmt, autoConvert: false))
                        e.Data.SetData(fmt, "");

                var text = Selection.Text;
                e.Data.SetData(DataFormats.Text, text);
                e.Data.SetData(DataFormats.UnicodeText, text);
            }

            base.OnPreviewDragEnter(e);
        }

        private static void PreviewCanExecuteHandler(object sender, CanExecuteRoutedEventArgs e)
            => (sender as RichTextBox)?.OnPreviewCanExecute(e);
        
        private static void PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
            => (sender as RichTextBox)?.OnPreviewExecuted(e);

        /// <summary>
        /// Intercept some high level command.CanExecute calls to ensure consistency.
        /// </summary>
        void OnPreviewCanExecute(CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Undo)
            {
                e.CanExecute = m_undo_manager.CanUndo();
                e.Handled = true;
            }
            else if (e.Command == ApplicationCommands.Redo)
            {
                e.CanExecute = m_undo_manager.CanRedo();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Intercept some high level command.Execute calls to ensure consistency.
        /// </summary>
        protected void OnPreviewExecuted(ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Undo)
            {
                Undo();
                e.Handled = true;
            }

            if (e.Command == ApplicationCommands.Redo)
            {
                Redo();
                e.Handled = true;
            }

            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut)
            {
                // Add BBCode markups to clipboard
                m_pending_change = true;
                Selection.GetBBCodeSpans().ForAll(x => x.IsExpanded = true);
                m_pending_change = false;

                // Make sure the clipboard contains the proper emoji characters.
                var selection = Selection.Text;
                if (e.Command == ApplicationCommands.Cut)
                    Cut();
                try { Clipboard.SetText(selection); } catch { }
                e.Handled = true;

                // Restore BBCode markups visibility
                UpdateBBCodeMarkupsVisibility();
            }
        }

        /// <summary>
        /// Replace Emoji characters with EmojiInline objects inside the document.
        /// </summary>
        protected override void OnTextChanged(Controls.TextChangedEventArgs e)
        {
            if (m_pending_change)
                return;

            if (m_pending_undo)
            {
                base.OnTextChanged(e);
                return;
            }

            m_pending_change = true;

            BeginChange();

            Document.ApplyBBCode(BBCodeConfig);
            Document.SubstituteGlyphs(
                (ColonSyntax ? SubstituteOptions.ColonSyntax : SubstituteOptions.None) |
                (ColorBlend ? SubstituteOptions.ColorBlend : SubstituteOptions.None));

            EndChange();

            base.OnTextChanged(e);

            // FIXME: make this call lazy inside Text.get()
            SetValue(TextProperty, new TextSelection(Document.ContentStart, Document.ContentEnd).Text);

            m_pending_change = false;

            m_undo_manager.Update(this, e.UndoAction);

#if DEBUG
            try
            {
                var xaml = XamlWriter.Save(Document);
                xaml = Regex.Replace(xaml, "<FlowDocument[^>]*>", "<FlowDocument>");
                SetValue(XamlTextProperty, xaml);
            }
            catch { }
#endif
        }

        private void OnTextPropertyChanged(string text)
        {
            if (m_pending_change)
                return;

            Document.Blocks.Clear();
            Document.Blocks.Add(new Paragraph(new Run(text)));
            CaretPosition = Document.ContentEnd;
        }

        private void OnColorBlendChanged(bool color_blend)
            => EmojiInlines.ForAll(e => e.Foreground = color_blend ? Foreground : Brushes.Black);

        private bool m_pending_change = false;
        private bool m_pending_undo = false;

        private TextSelection m_override_selection;

        public new TextSelection Selection { get; private set; }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(RichTextBox), new FrameworkPropertyMetadata("",
                (o, e) => (o as RichTextBox)?.OnTextPropertyChanged(e.NewValue as string))
            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.LostFocus });

        public bool ColonSyntax
        {
            get => (bool)GetValue(ColonSyntaxProperty);
            set => SetValue(ColonSyntaxProperty, value);
        }

        public static readonly DependencyProperty ColonSyntaxProperty =
             DependencyProperty.Register(nameof(ColonSyntax), typeof(bool), typeof(RichTextBox),
                 new PropertyMetadata(false));

        public bool ColorBlend
        {
            get => (bool)GetValue(ColorBlendProperty);
            set => SetValue(ColorBlendProperty, value);
        }

        public static readonly DependencyProperty ColorBlendProperty =
             DependencyProperty.Register(nameof(ColorBlend), typeof(bool), typeof(RichTextBox),
                 new PropertyMetadata(false, (o, e) => (o as RichTextBox)?.OnColorBlendChanged((bool)e.NewValue)));

        public IEnumerable<EmojiInline> EmojiInlines
        {
            get
            {
                for (var p = Document.ContentStart; p != null; p = p.GetNextContextPosition(LogicalDirection.Forward))
                    if (p.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.ElementStart)
                        if (p.GetAdjacentElement(LogicalDirection.Forward) is EmojiInline emoji)
                            yield return emoji;
            }
        }

        public IEnumerable<BBCodeSpan> BBCodeSpans => Document.GetBBCodeSpans();

        public BBCodeVisibility BBCodeMarkupVisibility
        {
            get => (BBCodeVisibility)GetValue(BBCodeMarkupVisibilityProperty);
            set => SetValue(BBCodeMarkupVisibilityProperty, value);
        }

        public static readonly DependencyProperty BBCodeMarkupVisibilityProperty = DependencyProperty.Register(
            nameof(BBCodeMarkupVisibility), typeof(BBCodeVisibility), typeof(RichTextBox),
            new FrameworkPropertyMetadata(BBCodeVisibility.Visible, (o,e) => (o as RichTextBox)?.UpdateBBCodeMarkupsVisibility())
            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

        public void UpdateBBCodeMarkupsVisibility()
        {
            m_pending_change = true;
            switch (BBCodeMarkupVisibility)
            {
                case BBCodeVisibility.Visible:
                    BBCodeSpans.ForAll(x => x.IsExpanded = true);
                    break;
                case BBCodeVisibility.Hidden:
                    BBCodeSpans.ForAll(x => x.IsExpanded = false);
                    break;
                case BBCodeVisibility.OnCaretInside:
                    var selected_spans = this.GetSelectedBBCodeSpans().ToList();
                    BBCodeSpans.ForAll(x => x.IsExpanded = selected_spans.Contains(x));
                    break;
            }
            m_pending_change = false;
        }

        public BBCodeConfig BBCodeConfig
        {
            get => (BBCodeConfig)GetValue(BBCodeConfigProperty);
            set => SetValue(BBCodeConfigProperty, value);
        }

        public static readonly DependencyProperty BBCodeConfigProperty = DependencyProperty.Register(
            nameof(BBCodeConfig), typeof(BBCodeConfig), typeof(RichTextBox),
            new FrameworkPropertyMetadata(null, (o,e) => (o as RichTextBox)?.OnBBCodeConfigChanged())
            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

        public void OnBBCodeConfigChanged()
        {
            m_pending_change = true;

            Document.ApplyBBCode(BBCodeConfig);
            Document.SubstituteGlyphs(
                (ColonSyntax ? SubstituteOptions.ColonSyntax : SubstituteOptions.None) |
                (ColorBlend ? SubstituteOptions.ColorBlend : SubstituteOptions.None));

            m_pending_change = false;

            // When it's on control initialization, override first undo state
            if (!IsLoaded)
                m_undo_manager.Update(this, Controls.UndoAction.Clear);
        }

#if DEBUG
        public string XamlText => (string)GetValue(XamlTextProperty);

        public static readonly DependencyProperty XamlTextProperty = DependencyProperty.Register(
            nameof(XamlText), typeof(string), typeof(RichTextBox),
            new PropertyMetadata(""));
#endif

        #region Caret Management

        public int GetCaretPosition()
            => Document.ContentStart.GetOffsetToPosition(CaretPosition);

        public void SetCaretPosition(int char_offset)
            => CaretPosition = Document.ContentStart.GetPositionAtOffset(char_offset);

        #endregion

        #region Undo/Redo

        private UndoManager m_undo_manager = new UndoManager();

        private new void Undo()
        {
            m_pending_undo = true;
            m_undo_manager.Undo(this);
            m_pending_undo = false;
            UpdateBBCodeMarkupsVisibility();
        }

        private new void Redo()
        {
            m_pending_undo = true;
            m_undo_manager.Redo(this);
            m_pending_undo = false;
            UpdateBBCodeMarkupsVisibility();
        }

        #endregion
    }
}
