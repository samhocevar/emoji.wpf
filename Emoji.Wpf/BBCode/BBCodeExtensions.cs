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

using Stfu.Linq;
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
    // - merge adjacent similar markups
    // - evaluate performance impact on large texts and on a long use

    public static class BBCodeExtensions
    {
        private readonly static Regex _bbcode_regex = new Regex(@"\[(.+?)\](.*?)\[\/\1\]", RegexOptions.Compiled);

        private static List<BBCodeSpan> GetPointerParentSpans(TextPointer pointer, FlowDocument document)
        {
            var result = new List<BBCodeSpan>();
            var startb = pointer.GetNextContextPosition(LogicalDirection.Backward);
            var startf = pointer.GetNextContextPosition(LogicalDirection.Forward);

            if (startb != null && startf != null)
            {
                var elementb = startb.GetAdjacentElement(LogicalDirection.Backward);
                var elementf = startf.GetAdjacentElement(LogicalDirection.Forward);
                if (elementb is BBCodeSpan span1 && !result.Contains(span1)) result.Add(span1);
                if (elementf is BBCodeSpan span2 && !result.Contains(span2)) result.Add(span2);

                var parentb = document.GetBBCodeSpans().FirstOrDefault(x => x.Inlines.Contains(elementb));
                var parentf = document.GetBBCodeSpans().FirstOrDefault(x => x.Inlines.Contains(elementf));
                if (parentb != null && !result.Contains(parentb)) result.Add(parentb);
                if (parentf != null && !result.Contains(parentf)) result.Add(parentf);
            }

            return result;
        }

        /// <summary>
        /// Gets all BBCode spans containing the start or the end of the current selection in a <see cref="RichTextBox"/>
        /// </summary>
        public static IEnumerable<BBCodeSpan> GetSelectedBBCodeSpans(this RichTextBox rtb)
        {
            var spans = GetPointerParentSpans(rtb.Selection.Start, rtb.Document);

            if (rtb.Selection.Start != rtb.Selection.End)
                spans.AddRange(GetPointerParentSpans(rtb.Selection.End, rtb.Document));

            return spans.Distinct();
        }

        /// <summary>
        /// Gets all BBCode spans in a <see cref="FlowDocument"/>
        /// </summary>
        public static IEnumerable<BBCodeSpan> GetBBCodeSpans(this FlowDocument document)
            => GetBBCodeSpans(new TextRange(document.ContentStart, document.ContentEnd));

        /// <summary>
        /// Gets all BBCode spans between two <see cref="TextPointer"/>s
        /// </summary>
        public static IEnumerable<BBCodeSpan> GetBBCodeSpans(this TextRange text_range)
        {
            for (var p = text_range.Start; p != null && p != text_range.End; p = p.GetNextContextPosition(LogicalDirection.Forward))
                if (p.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.ElementStart)
                    if (p.GetAdjacentElement(LogicalDirection.Forward) is BBCodeSpan bbcode)
                        yield return bbcode;
        }

        /// <summary>
        /// Apply formatting on text containing BBCode markups in a <see cref="FlowDocument"/>
        /// </summary>
        public static void ApplyBBCode(this FlowDocument document, BBCodeConfig config)
        {
            if (document.Blocks.FirstBlock == null || config == null)
                return;

            // Expand all bbcode spans in order to have a correct caret position
            foreach (var span in document.GetBBCodeSpans())
                span.IsExpanded = true;

            // If our parent is a RichTextBox, try to retain the caret position
            // FIXME: doesn't work when text contains an emoji
            var rtb = document.Parent as RichTextBox;
            var caret_index = rtb != null ? new TextSelection(rtb.Document.ContentStart, rtb.CaretPosition).Text.Length : -1;
            var text = new TextSelection(document.ContentStart, document.ContentEnd).Text;

            foreach (var paragraph in document.Blocks.OfType<Paragraph>().ToList())
            {
                paragraph.Inlines.Clear();

                var cur = 0;
                var matches = _bbcode_regex.Matches(text);

                foreach (Match match in matches)
                {
                    var match_markup = match.Groups[1].Value;
                    var match_text = match.Groups[2].Value;
                    var markup = config.Markups.Find(x => x.Markup == match_markup);

                    if (markup == null)
                        continue;

                    // Insert unformatted text before the match
                    var unmatched_text = text.Substring(cur, match.Index - cur);
                    if (unmatched_text.Length > 0)
                        paragraph.Inlines.Add(unmatched_text);

                    // Insert BBCode span
                    paragraph.Inlines.Add(new BBCodeSpan(markup, match_text, document, config));

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
