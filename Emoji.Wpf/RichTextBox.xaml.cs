//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

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

                //var word = new TextRange(p, next);
                //Console.WriteLine("Word '{0}' Inline {1}", word.Text, word.Start.Parent is EmojiElement ? "Emoji" : "not Emoji");
                //Console.WriteLine(" ... p {0}", p.Parent is EmojiElement ? "Emoji" : p.Parent.GetType().ToString());

                var t = new TextRange(p, next);
                clipboard += t.Start.Parent is EmojiInline ? (t.Start.Parent as EmojiInline).Text
                                                           : t.Text;
            }

            Clipboard.SetText(clipboard);
            e.Handled = true;
            e.CancelCommand();
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(delegate { timer.Stop(); FixEmojis(); });
            timer.Start();

            base.OnTextChanged(e);

            // FIXME: debug
            //Console.WriteLine(XamlWriter.Save(Document));
        }

        private bool m_pending_change = false;

        private void FixEmojis()
        {
            if (m_pending_change)
                return;

            /* This will prevent our operation from polluting the undo buffer, but it
             * will create an infinite undo stack... need to fix this. */
            BeginChange();

            m_pending_change = true;

            TextPointer cur = Document.ContentStart;
            while (cur.CompareTo(Document.ContentEnd) < 0)
            {
                TextPointer next = cur.GetNextInsertionPosition(LogicalDirection.Forward);
                if (next == null)
                    break;

                TextRange word = new TextRange(cur, next);
                if (word.Text.Length > 0)
                {
                    // Test this so as to preserve caret position
                    bool caret_was_next = (0 == next.CompareTo(CaretPosition));

                    Inline inline;
                    // FIXME: this is a hack, normally we should split into Runs and EmojiInlines
                    if (word.Text == "\n")
                        inline = new LineBreak();
                    else
                        inline = new EmojiInline() { Text = word.Text, FontSize = FontSize, FallbackBrush = Foreground };

                    next = Replace(word, inline);
                    if (caret_was_next)
                        CaretPosition = next;
                }

                cur = next;
            }

            EndChange();

            m_pending_change = false;
        }

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
    }
}

