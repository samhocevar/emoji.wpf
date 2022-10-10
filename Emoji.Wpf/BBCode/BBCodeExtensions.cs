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

using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;

namespace Emoji.Wpf.BBCode
{
    // TODO:
    // - merge adjacent similar markups
    // - evaluate performance impact on large texts and on a long use

    public static class BBCodeExtensions
    {
        private readonly static Regex _span_regex = new Regex(@"\[(.+?)\](.*?)\[\/\1\]", RegexOptions.Compiled);
        private readonly static Regex _tag_regex = new Regex(@"\[.+?\]", RegexOptions.Compiled);

        public static string GetBBCodePlainText(this string text) => _tag_regex.Replace(text, "");

        public static bool IsBBCode(this string text) => _span_regex.IsMatch(text);

        public readonly static List<BBCodeMarkup> DefaultMarkups = new List<BBCodeMarkup>()
        {
            new BBCodeMarkup
            {
                Name = "Bold",
                Markup = "b",
                FontWeight = FontWeights.Bold,
                Shortcut = "Ctrl+B"
            },
            new BBCodeMarkup
            {
                Name = "Italic",
                Markup = "i",
                FontStyle = FontStyles.Italic,
                Shortcut = "Ctrl+I"
            },
            new BBCodeMarkup
            {
                Name = "Underline",
                Markup = "u",
                TextDecorations = TextDecorations.Underline,
                Shortcut = "Ctrl+U"
            },
            new BBCodeMarkup
            {
                Name = "Strikethrough",
                Markup = "s",
                TextDecorations = TextDecorations.Strikethrough
            }
        };

        /// <summary>
        /// Gets all elements of a given type in a <see cref="FlowDocument"/>.
        /// </summary>
        public static IEnumerable<T> GetElements<T>(this FlowDocument document)
        {
            for (var p = document.ContentStart; p != null; p = p.GetNextContextPosition(LogicalDirection.Forward))
                if (p.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.ElementStart)
                    if (p.GetAdjacentElement(LogicalDirection.Forward) is T element)
                        yield return element;
        }

        /// <summary>
        /// Shortcut for getting valid BBCode spans in a <see cref="FlowDocument"/>.
        /// </summary>
        public static IEnumerable<BBCodeSpan> GetBBCodeSpans(this FlowDocument document)
            => document.GetElements<BBCodeSpan>().Where(x => x.IsValid);

        /// <summary>
        /// Get the BBCode span that contains this <see cref="TextPointer"/>.
        /// </summary>
        public static BBCodeSpan GetParentBBCodeSpan(this TextPointer pointer, FlowDocument document)
        {
            if (!pointer.IsInSameDocument(document.ContentStart))
                return null;

            return document.GetBBCodeSpans().FirstOrDefault(x => x.ContentStart.CompareTo(pointer) <= 0 &&
                                                                 x.ContentEnd.CompareTo(pointer) >= 0);
        }

        /// <summary>
        /// Gets all BBCode spans containing the start or the end of the current selection in a <see cref="RichTextBox"/>
        /// </summary>
        public static IEnumerable<BBCodeSpan> GetParentBBCodeSpans(this TextRange text_range, FlowDocument document)
        {
            var span = text_range.Start.GetParentBBCodeSpan(document);
            if (span != null)
                yield return span;

            if (text_range.Start != text_range.End)
            {
                span = text_range.End.GetParentBBCodeSpan(document);
                if (span != null)
                    yield return span;
            }
        }

        /// <summary>
        /// Insert markup tags around a text range.
        /// </summary>
        /// <param name="text_range">Range of text to enclose with the markup tags.</param>
        /// <param name="markup">Markup to apply.</param>
        /// <param name="document">Text range parent document.</param>
        public static void ApplyBBCodeMarkup(this TextRange text_range, BBCodeMarkup markup, FlowDocument document)
        {
            // TODO: improve markup overriding and overlapping
            var text = text_range.Text;
            var markup_open = $"[{markup.Markup}]";
            var markup_close = $"[/{markup.Markup}]";

            // Get parent spans of the start and end pointers of the text range
            var parent1 = text_range.Start.GetParentBBCodeSpan(document);
            var parent2 = text_range.End.GetParentBBCodeSpan(document);

            // If the range is inside a bbcode span, nothing needs to be done
            if (parent1 != null && parent2 != null && parent1.Markup == markup.Markup && parent1 == parent2)
                return;

            // Remove all markup tags
            text = text.Replace(markup_open, "");
            text = text.Replace(markup_close, "");

            // Do not write opening/closing tags when they are already within a tagged range
            if (parent1?.Markup == markup.Markup)
                markup_open = "";
            if (parent2?.Markup == markup.Markup)
                markup_close = "";

            // Replace the text. This will call OntextChanged and apply formatting.
            text_range.Text = markup_open + text + markup_close;
        }

        /// <summary>
        /// Apply formatting on text containing BBCode markups in a <see cref="FlowDocument"/>
        /// </summary>
        public static void ApplyBBCode(this FlowDocument document, BBCodeConfig config)
        {
            if (document.Blocks.FirstBlock == null || config == null || config.Markups == null)
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
                paragraph.Inlines.Clear(); //FIXME: this call has a big impact on performance!

                var cur = 0;
                var matches = _span_regex.Matches(text);

                // TODO: merge consecutive matches having the same markup

                foreach (Match match in matches)
                {
                    var match_markup = match.Groups[1].Value;
                    var match_text = match.Groups[2].Value;
                    var markup = DefaultMarkups.Find(x => x.Markup == match_markup) ??
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
