//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2023 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using Stfu.Linq;
using System.Collections.Generic;
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

    public class RichTextBox : Controls.RichTextBox, IEmojiControl
    {
        public RichTextBox()
        {
            CommandManager.AddPreviewExecutedHandler(this, PreviewExecuted);
            SetValue(Block.LineHeightProperty, 1.0);
            Selection = new TextSelection(Document.ContentStart, Document.ContentStart);
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
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // If the user clicked on an emoji, remember where it was. The default RichTextBox
            // behaviour is to select the whole InlineUIContainer instead of positioning the
            // caret. But in the case of a single click we do want to position the caret, so
            // we override the unwanted behaviour.
            var hit = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (hit?.VisualHit is Controls.Image im && im.Parent is EmojiInline emoji)
            {
                // Single click: cancel selection and position caret instead
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

        private static void PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
            => (sender as RichTextBox)?.OnPreviewExecuted(e);

        /// <summary>
        /// Intercept some high level commands to ensure consistency.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnPreviewExecuted(ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut)
            {
                /// Make sure the clipboard contains the proper emoji characters.
                var selection = Selection.Text;
                if (e.Command == ApplicationCommands.Cut)
                    Cut();
                try { Clipboard.SetText(selection); } catch { }
                e.Handled = true;
            }
        }

        /// <summary>
        /// Replace Emoji characters with EmojiInline objects inside the document.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(Controls.TextChangedEventArgs e)
        {
            // Protect against recursive changes (triggered by EndChange)
            if (m_pending_change)
                return;

            m_pending_change = true;

            base.OnTextChanged(e);

            // Prevent our operation from polluting the undo buffer
            BeginChange();

            foreach (var change in e.Changes.Where(c => c.AddedLength > 0).Reverse())
            {
                // FIXME: when using keyboard input methods, characters are received one by one.
                // We need to backtrack to the possible beginning of the emoji to make sure we
                // perform a full substitution. The below code works in simple cases, but will
                // not work if a substitution was already performed before the end of the emoji.
                int start = change.Offset, end = start + change.AddedLength;
                if (start == m_last_change_end)
                    start = m_last_change_start;
                m_last_change_start = start;
                m_last_change_end = end;

                var range = new TextRange(Document.ContentStart.GetPositionAtOffset(start),
                                          Document.ContentStart.GetPositionAtOffset(end));

                FlowDocumentExtensions.SubstituteGlyphsInRange(range,
                    Document.FontSize, Document.Foreground, this,
                    (ColonSyntax ? SubstituteOptions.ColonSyntax : SubstituteOptions.None) |
                    (ColorBlend ? SubstituteOptions.ColorBlend : SubstituteOptions.None));
            }

            EndChange();

            // FIXME: make this call lazy inside Text.get()?
            SetValue(TextProperty, new TextSelection(Document.ContentStart, Document.ContentEnd).Text);

            m_pending_change = false;
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

        private int m_last_change_start = -1;
        private int m_last_change_end = -1;

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

#if DEBUG
        public string XamlText => (string)GetValue(XamlTextProperty);

        public static readonly DependencyProperty XamlTextProperty = DependencyProperty.Register(
            nameof(XamlText), typeof(string), typeof(RichTextBox),
            new PropertyMetadata(""));
#endif
    }
}
