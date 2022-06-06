//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//                   2021 Victor Irzak <victor.irzak@zomp.com>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    // TODO:
    // - fix caret bug when text contains emoji(s)
    // - show only the markups that enclose the caret, as in Typora
    // - evaluate performance impact
    // - improve undo/redo performance :
    //     - store undo state objects by deserializing them asynchronously after serialization ?
    //     - don't override current state on key press
    // - move markups definitions list to a DependencyProperty on the control

    public static class BBCodeExtensions
    {
        private readonly static Regex _bbcode_regex = new Regex(@"\[(.+?)\](.*?)\[\/\1\]", RegexOptions.Compiled);

        private static List<BBCodeMarkup> _markups = new List<BBCodeMarkup>()
        {
            new BBCodeMarkup("Bold", "b", font_weight: FontWeights.Bold),
            new BBCodeMarkup("Test", "test", foreground: Colors.Blue),
        };

        /// <summary>
        /// Apply text formatted with BBCode markups in a FlowDocument
        /// </summary>
        public static void ApplyBBCodeFormatting(this FlowDocument document)
        {
            if (document.Blocks.FirstBlock == null)
                return;

            var text = new TextSelection(document.ContentStart, document.ContentEnd).Text;

            // If our parent is a RichTextBox, try to retain the caret position
            // FIXME: doesn't work when text contains an emoji
            RichTextBox rtb = document.Parent as RichTextBox;
            TextPointer caret = rtb?.CaretPosition;
            var caret_index = new TextRange(rtb.Document.ContentStart, rtb.CaretPosition).Text.Length;

            foreach (var paragraph in document.Blocks.OfType<Paragraph>().ToList())
            {
                paragraph.Inlines.Clear();

                var cur = 0;
                var matches = _bbcode_regex.Matches(text);

                foreach (Match match in matches)
                {
                    var match_markup = match.Groups[1].Value;
                    var match_text = match.Groups[2].Value;
                    var markup = _markups.Find(x => x.Markup == match_markup);

                    if (markup == null)
                        continue;

                    // Insert unformatted text before the match
                    var unmatched_text = text.Substring(cur, match.Index - cur);
                    if (unmatched_text.Length > 0)
                        paragraph.Inlines.Add(unmatched_text);

                    // Insert BBCode span
                    var span = new BBCodeSpan(markup, match_text);
                    paragraph.Inlines.Add(span);
                    span.IsExpanded = false;

                    // Move cursor to the end of the match
                    cur = match.Index + match.Length;
                }

                var unformatted_end_text = text.Substring(cur, text.Length - cur);
                paragraph.Inlines.Add(unformatted_end_text);
            }

            // Restore caret position
            if (rtb != null)
                rtb.CaretPosition = rtb.Document.ContentStart.GetPositionAtCharOffset(caret_index);
        }
    }
}
