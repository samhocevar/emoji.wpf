//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2020 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Emoji.Wpf
{
    public partial class RichTextBox : System.Windows.Controls.RichTextBox
    {
        public RichTextBox()
        {
            SetValue(Block.LineHeightProperty, 1.0);
            DataObject.AddCopyingHandler(this, new DataObjectCopyingEventHandler(OnCopy));
        }

        protected void OnCopy(object o, DataObjectCopyingEventArgs e)
        {
            string clipboard = "";

            for (TextPointer p = Selection.Start, next = null;
                 p != null && p.CompareTo(Selection.End) < 0;
                 p = next)
            {
                next = p.GetNextInsertionPosition(LogicalDirection.Forward);
                if (next == null)
                    break;

                var emoji = (next.Parent as Run)?.PreviousInline as EmojiInline;
                if (emoji == null && next.Parent != p.Parent)
                    emoji = (p.Parent as Run)?.NextInline as EmojiInline;
                if (emoji != null && (p.Parent as Run)?.PreviousInline != emoji)
                    clipboard += emoji?.Text;
                else
                    clipboard += new TextRange(p, next).Text;
            }

            Clipboard.SetText(clipboard);
            e.Handled = true;
            e.CancelCommand();
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (m_pending_change)
                return;

            m_pending_change = true;

            base.OnTextChanged(e);

            /* This will prevent our operation from polluting the undo buffer, but it
             * will create an infinite undo stack... need to fix this. */
            BeginChange();

            TextPointer cur = Document.ContentStart;
            while (cur.CompareTo(Document.ContentEnd) < 0)
            {
                TextPointer next = cur.GetNextInsertionPosition(LogicalDirection.Forward);
                if (next == null)
                    break;

                TextRange word = new TextRange(cur, next);
                if (EmojiData.MatchOne.IsMatch(word.Text))
                {
                    Inline inline = new EmojiInline()
                    {
                        Text = word.Text,
                        FontSize = FontSize,
                        FallbackBrush = Foreground,
                    };

                    // Preserve caret position
                    bool caret_was_next = (0 == next.CompareTo(CaretPosition));
                    next = Replace(word, inline);
                    if (caret_was_next)
                        CaretPosition = next;
                }

                cur = next;
            }

            EndChange();

            m_pending_change = false;

            // FIXME: this could be done on-demand by detecting GetValue() calls
            var xaml = XamlWriter.Save(Document);
            SetValue(XamlTextProperty, xaml);
        }

        private bool m_pending_change = false;

        public TextPointer Replace(TextRange range, Inline inline)
        {
            var run = range.Start.Parent as Run;
            if (run == null)
                return range.End;

            var before = new TextRange(run.ContentStart, range.Start).Text;
            var after = new TextRange(range.End, run.ContentEnd).Text;
            var inlines = run.SiblingInlines;

            /* Insert new inlines in reverse order after the run */
            if (!string.IsNullOrEmpty(after))
                inlines.InsertAfter(run, new Run(after));

            inlines.InsertAfter(run, inline);

            if (!string.IsNullOrEmpty(before))
                inlines.InsertAfter(run, new Run(before));

            TextPointer ret = inline.ContentEnd; // FIXME
            inlines.Remove(run);
            return ret;
        }

        public string XamlText => (string)GetValue(XamlTextProperty);

        public static readonly DependencyProperty XamlTextProperty = DependencyProperty.Register(
            nameof(XamlText), typeof(string), typeof(RichTextBox),
            new PropertyMetadata(""));
    }
}

