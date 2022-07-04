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

        private readonly static List<BBCodeMarkup> _default_markups = new List<BBCodeMarkup>()
        {
            new BBCodeMarkup
            {
                Name = "Bold",
                Markup = "b",
                FontWeight = FontWeights.Bold
            },
            new BBCodeMarkup
            {
                Name = "Italic",
                Markup = "i",
                FontStyle = FontStyles.Italic
            },
            new BBCodeMarkup
            {
                Name = "Underline",
                Markup = "u",
                TextDecorations = TextDecorations.Underline
            },
            new BBCodeMarkup
            {
                Name = "Strikethrough",
                Markup = "s",
                TextDecorations = TextDecorations.Strikethrough
            }
        };

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
                    if (p.GetAdjacentElement(LogicalDirection.Forward) is BBCodeSpan bbcode && bbcode.IsValid)
                        yield return bbcode;
        }

        /// <summary>
        /// Apply formatting on text containing BBCode markups in a <see cref="FlowDocument"/>
        /// </summary>
        public static void ApplyBBCode(this FlowDocument document, BBCodeConfig config)
        {
            if (document.Blocks.FirstBlock == null || config == null)
                return;

            var rtb = document.Parent as RichTextBox;

            // Expand all bbcode spans in order to have a correct caret position
            foreach (var span in document.GetBBCodeSpans())
                span.IsExpanded = true;

            // Rebuild every paragraph inlines
            foreach (var paragraph in document.Blocks.OfType<Paragraph>().ToList())
            {
                // If caret is in this paragraph, retain its position
                var caret_index = -1;
                if (rtb.CaretPosition.CompareTo(paragraph.ContentStart) >= 0 &&
                    rtb.CaretPosition.CompareTo(paragraph.ContentEnd) <= 0)
                    caret_index = new TextSelection(paragraph.ContentStart, rtb.CaretPosition).Text.Length;

                // Save the text before rebuilding the paragraph inlines
                var text = new TextSelection(paragraph.ContentStart, paragraph.ContentEnd).Text;
                paragraph.Inlines.Clear();

                var cur = 0;
                var matches = _bbcode_regex.Matches(text);

                foreach (Match match in matches)
                {
                    var match_markup = match.Groups[1].Value;
                    var match_text = match.Groups[2].Value;
                    var markup = _default_markups.Find(x => x.Markup == match_markup) ??
                                 config.Markups.Find(x => x.Markup == match_markup);

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

                // Restore caret position
                if (caret_index > -1)
                    rtb.CaretPosition = paragraph.ContentStart.GetPositionAtCharOffset(caret_index);
            }
        }
    }
}
