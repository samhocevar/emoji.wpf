//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//                   2022 Charles Spitzer <charles.spitzer@dont-nod.com>
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
using System.Windows.Markup;
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
                var is_first_paragraph = true;

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
                            var element = p.GetAdjacentElement(LogicalDirection.Forward);
                            if (element is EmojiInline emoji)
                                buf.Append(emoji.Text);
                            else if (element is Paragraph && !is_first_paragraph)
                                buf.Append('\n');
                            break;

                        case TextPointerContext.ElementEnd:
                            if (p.GetAdjacentElement(LogicalDirection.Forward) is Paragraph)
                                is_first_paragraph = false;
                            break;

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

    public enum BBCodeMarkupVisibility
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
            BBCodeShortcutCommand = new BBCodeShortcutCommand(this);
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
            m_last_caret_pos = GetCaretPosition();

            if (IsBBCodeEnabled && !m_pending_change)
                UpdateBBCodeMarkupsVisibility();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // If the user clicked on an emoji, remember where it was. The default RichTextBox
            // behaviour is to select the whole InlineUIContainer instead of positioning the
            // caret, so in the case of a single click we want to cancel that.
            var hit = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (hit?.VisualHit is Controls.Image im && im.Parent is EmojiInline emoji)
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
            if (IsBBCodeEnabled)
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
        }

        /// <summary>
        /// Intercept some high level command.Execute calls to ensure consistency.
        /// </summary>
        protected void OnPreviewExecuted(ExecutedRoutedEventArgs e)
        {
            if (IsBBCodeEnabled)
            {
                if (e.Command == ApplicationCommands.Undo)
                {
                    CustomUndo();
                    e.Handled = true;
                }

                if (e.Command == ApplicationCommands.Redo)
                {
                    CustomRedo();
                    e.Handled = true;
                }
            }

            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut)
            {
                // We want to add BBCode markups to clipboard
                using (new BBCodeMarkupsExpander(this))
                {
                    // Make sure the clipboard contains the proper emoji characters.
                    var selection = Selection.Text;
                    if (e.Command == ApplicationCommands.Cut)
                        Cut();
                    try { Clipboard.SetText(selection); } catch { }
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Replace Emoji characters with EmojiInline objects inside the document.
        /// </summary>
        protected override void OnTextChanged(Controls.TextChangedEventArgs e)
        {
            if (m_pending_change)
                return;

            if (IsBBCodeEnabled && m_pending_undo)
            {
                using (new PendingChangeBlock(this))
                {
                    base.OnTextChanged(e);
                    SetValue(TextProperty, BBCodeText);
                    return;
                }
            }

            using (new PendingChangeBlock(this))
            {
                BeginChange();

                if (IsBBCodeEnabled)
                    Document.ApplyBBCode(BBCodeConfig);

                Document.SubstituteGlyphs(
                    (ColonSyntax ? SubstituteOptions.ColonSyntax : SubstituteOptions.None) |
                    (ColorBlend ? SubstituteOptions.ColorBlend : SubstituteOptions.None));

                EndChange();

                base.OnTextChanged(e);

                // FIXME: make this call lazy inside Text.get()
                SetValue(TextProperty, new TextSelection(Document.ContentStart, Document.ContentEnd).Text);

                if (IsBBCodeEnabled)
                    m_undo_manager.Update(this, e.UndoAction);
            }

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

        private void OnColorBlendChanged(bool color_blend)
            => EmojiInlines.ForAll(e => e.Foreground = color_blend ? Foreground : Brushes.Black);

        private bool m_pending_change = false;

        private TextSelection m_override_selection;

        public new TextSelection Selection { get; private set; }

        #region Text Property

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(RichTextBox),
            new FrameworkPropertyMetadata("", (o, e) => (o as RichTextBox)?.OnTextPropertyChanged(e.NewValue as string))
            {
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                BindsTwoWayByDefault = true
            });

        private void OnTextPropertyChanged(string text)
        {
            if (m_pending_change)
                return;

            using (new PendingChangeBlock(this))
                Document.Blocks.Clear();

            var paragraphs = text.Split('\n').Select(x => new Paragraph(new Run(x)));
            Document.Blocks.AddRange(paragraphs);
            UpdateBBCodeMarkupsVisibility();
        }

        #endregion

        public bool ColonSyntax
        {
            get => (bool)GetValue(ColonSyntaxProperty);
            set => SetValue(ColonSyntaxProperty, value);
        }

        public static readonly DependencyProperty ColonSyntaxProperty = DependencyProperty.Register(
                 nameof(ColonSyntax),
                 typeof(bool),
                 typeof(RichTextBox),
                 new PropertyMetadata(false));

        public bool ColorBlend
        {
            get => (bool)GetValue(ColorBlendProperty);
            set => SetValue(ColorBlendProperty, value);
        }

        public static readonly DependencyProperty ColorBlendProperty = DependencyProperty.Register(
            nameof(ColorBlend),
            typeof(bool),
            typeof(RichTextBox),
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

        #region BBCode

        private readonly BBCodeShortcutCommand BBCodeShortcutCommand;

        public IEnumerable<BBCodeSpan> BBCodeSpans => Document.GetBBCodeSpans();

        public bool IsBBCodeEnabled
        {
            get => (bool)GetValue(IsBBCodeEnabledProperty) && BBCodeConfig != null;
            set => SetValue(IsBBCodeEnabledProperty, value);
        }

        public static readonly DependencyProperty IsBBCodeEnabledProperty = DependencyProperty.Register(
            nameof(IsBBCodeEnabled),
            typeof(bool),
            typeof(RichTextBox),
            new FrameworkPropertyMetadata(false, (o, e) => (o as RichTextBox)?.OnIsBBCodeEnabledPropertyChanged((bool)e.NewValue))
            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

        private void OnIsBBCodeEnabledPropertyChanged(bool value) => OnTextPropertyChanged(BBCodeText);

        public string BBCodeText
        {
            get
            {
                using (new BBCodeMarkupsExpander(this))
                    return new TextSelection(Document.ContentStart, Document.ContentEnd).Text;
            }
        }

        public BBCodeMarkupVisibility BBCodeMarkupVisibility
        {
            get => (BBCodeMarkupVisibility)GetValue(BBCodeMarkupVisibilityProperty);
            set => SetValue(BBCodeMarkupVisibilityProperty, value);
        }

        public static readonly DependencyProperty BBCodeMarkupVisibilityProperty = DependencyProperty.Register(
            nameof(BBCodeMarkupVisibility),
            typeof(BBCodeMarkupVisibility),
            typeof(RichTextBox),
            new FrameworkPropertyMetadata(BBCodeMarkupVisibility.Visible, (o,e) => (o as RichTextBox)?.UpdateBBCodeMarkupsVisibility())
            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

        public void UpdateBBCodeMarkupsVisibility()
        {
            using (new PendingChangeBlock(this))
            {
                switch (BBCodeMarkupVisibility)
                {
                    case BBCodeMarkupVisibility.Visible:
                        BBCodeSpans.ForAll(x => x.IsExpanded = true);
                        break;
                    case BBCodeMarkupVisibility.Hidden:
                        BBCodeSpans.ForAll(x => x.IsExpanded = false);
                        break;
                    case BBCodeMarkupVisibility.OnCaretInside:
                        var selected_spans = Selection.GetParentBBCodeSpans(Document).ToList();
                        BBCodeSpans.ForAll(x => x.IsExpanded = selected_spans.Contains(x));
                        break;
                }
            }
        }

        private BBCodeConfig BBCodeConfig = new BBCodeConfig();

        public List<BBCodeMarkup> BBCodeMarkups
        {
            get => (List<BBCodeMarkup>)GetValue(BBCodeMarkupsProperty);
            set => SetValue(BBCodeMarkupsProperty, value);
        }

        public static readonly DependencyProperty BBCodeMarkupsProperty = DependencyProperty.Register(
            nameof(BBCodeMarkups),
            typeof(List<BBCodeMarkup>),
            typeof(RichTextBox),
            new FrameworkPropertyMetadata(new List<BBCodeMarkup>(), (o,e) => (o as RichTextBox)?.OnBBCodeConfigChanged())
            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

        public double BBCodeMarkupFontScale
        {
            get => Math.Max((double)GetValue(BBCodeMarkupFontScaleProperty), 0.5);
            set => SetValue(BBCodeMarkupFontScaleProperty, value);
        }

        public static readonly DependencyProperty BBCodeMarkupFontScaleProperty = DependencyProperty.Register(
            nameof(BBCodeMarkupFontScale),
            typeof(double),
            typeof(RichTextBox),
            new FrameworkPropertyMetadata(1.0, (o, e) => (o as RichTextBox)?.OnBBCodeConfigChanged())
            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

        public void OnBBCodeConfigChanged()
        {
            BBCodeConfig.Markups = BBCodeMarkups;
            BBCodeConfig.MarkupFontScale = BBCodeMarkupFontScale;

            InputBindings.Clear();
            var converter = new KeyGestureConverter();
            var markups = BBCodeExtensions.DefaultMarkups.Union(BBCodeConfig.Markups);

            foreach (var markup in markups.Where(x => x.Shortcut != null))
            {
                try
                {
                    var key_gesture = converter.ConvertFrom(markup.Shortcut) as KeyGesture;
                    InputBindings.Add(new KeyBinding(BBCodeShortcutCommand, key_gesture) { CommandParameter = markup });
                }
                catch { }
            }

            using (new PendingChangeBlock(this))
            {
                if (IsBBCodeEnabled)
                    Document.ApplyBBCode(BBCodeConfig);

                Document.SubstituteGlyphs(
                    (ColonSyntax ? SubstituteOptions.ColonSyntax : SubstituteOptions.None) |
                    (ColorBlend ? SubstituteOptions.ColorBlend : SubstituteOptions.None));
            }

            // When it's on control initialization, override first undo state
            if (!IsLoaded)
                m_undo_manager.Update(this, Controls.UndoAction.Clear);
        }

        #endregion

        #region BBCode Undo/Redo Override

        private UndoManager m_undo_manager = new UndoManager();
        private bool m_pending_undo = false;

        private int m_last_caret_pos = -1;
        public int LastCaretPosition => m_last_caret_pos;

        public int GetCaretPosition()
            => Document.ContentStart.GetOffsetToPosition(CaretPosition);

        public void SetCaretPosition(int char_offset)
        {
            var pointer = Document.ContentStart.GetPositionAtOffset(char_offset);
            if (pointer != null)
                CaretPosition = pointer;
        }

        private void CustomUndo()
        {
            m_pending_undo = true;
            m_undo_manager.Undo(this);
            UpdateBBCodeMarkupsVisibility();
            m_pending_undo = false;
        }

        private void CustomRedo()
        {
            m_pending_undo = true;
            m_undo_manager.Redo(this);
            UpdateBBCodeMarkupsVisibility();
            m_pending_undo = false;
        }

        #endregion

        #region Inner Classes

        /// <summary>
        /// Allows temporary disable of OnTextChanged calls
        /// </summary>
        private class PendingChangeBlock : IDisposable
        {
            private RichTextBox m_rtb;
            private bool m_pending_change_before;

            public PendingChangeBlock(RichTextBox rtb)
            {
                m_rtb = rtb;
                m_pending_change_before = rtb.m_pending_change;
                m_rtb.m_pending_change = true;
            }

            public void Dispose()
            {
                m_rtb.m_pending_change = m_pending_change_before;
            }
        }

        /// <summary>
        /// Allows temporary enable of all markups in a using block
        /// </summary>
        private class BBCodeMarkupsExpander : IDisposable
        {
            private RichTextBox m_rtb;

            public BBCodeMarkupsExpander(RichTextBox rtb)
            {
                m_rtb = rtb;
                using (new PendingChangeBlock(m_rtb))
                    rtb.Document.GetBBCodeSpans().ForAll(x => x.IsExpanded = true);
            }

            public void Dispose()
            {
                if (m_rtb.IsBBCodeEnabled)
                    m_rtb.UpdateBBCodeMarkupsVisibility();
            }
        }

        #endregion

#if DEBUG
        public string XamlText => (string)GetValue(XamlTextProperty);

        public static readonly DependencyProperty XamlTextProperty = DependencyProperty.Register(
            nameof(XamlText), typeof(string), typeof(RichTextBox),
            new PropertyMetadata(""));
#endif
    }
}
