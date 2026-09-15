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

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
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
        /// Gets the paragraphs of a <see cref="FlowDocument"/> overlapping the given text ranges.
        /// </summary>
        public static IEnumerable<Paragraph> GetParagraphs(this FlowDocument document, IEnumerable<TextRange> ranges)
            => document.Blocks.OfType<Paragraph>()
                       .Where(x => ranges.Any(y => x.ContentStart.CompareTo(y.End) <= 0 && x.ContentEnd.CompareTo(y.Start) >= 0));

        /// <summary>
        /// Apply formatting on text containing BBCode markups in a <see cref="FlowDocument"/>
        /// </summary>
        public static void ApplyBBCode(this FlowDocument document, BBCodeConfig config)
            => document.ApplyBBCode(config, document.Blocks.OfType<Paragraph>().ToList());

        /// <summary>
        /// Apply formatting on text containing BBCode markups in some paragraphs of a <see cref="FlowDocument"/>
        /// and returns the paragraphs whose inlines were rebuilt
        /// </summary>
        public static List<Paragraph> ApplyBBCode(this FlowDocument document, BBCodeConfig config, IEnumerable<Paragraph> paragraphs)
        {
            var rebuilt = new List<Paragraph>();
            if (config == null || config.Markups == null)
                return rebuilt;

            var rtb = document.Parent as RichTextBox;

            // Expand all bbcode spans so paragraph texts and caret offsets include the tags
            foreach (var span in document.GetBBCodeSpans())
                span.IsExpanded = true;

            foreach (var paragraph in paragraphs)
            {
                var text = new TextSelection(paragraph.ContentStart, paragraph.ContentEnd).Text;
                var segments = ParseBBCode(text, config);

                // Clearing and rebuilding the inlines is only worth it when they no longer match the text
                if (paragraph.HasBBCodeSegments(segments))
                    continue;

                // If caret is in this paragraph, retain its position
                var caret_index = -1;
                if (rtb != null &&
                    rtb.CaretPosition.CompareTo(paragraph.ContentStart) >= 0 &&
                    rtb.CaretPosition.CompareTo(paragraph.ContentEnd) <= 0)
                    caret_index = new TextSelection(paragraph.ContentStart, rtb.CaretPosition).Text.Length;

                // Rebuild the paragraph inlines
                paragraph.Inlines.Clear();
                foreach (var segment in segments)
                    if (segment.Markup == null)
                        paragraph.Inlines.Add(segment.Text);
                    else
                        paragraph.Inlines.Add(new BBCodeSpan(FindMarkup(config, segment.Markup), segment.Text, document, config));

                // Restore caret position
                if (caret_index > -1)
                    rtb.CaretPosition = paragraph.ContentStart.GetPositionAtCharOffset(caret_index);

                rebuilt.Add(paragraph);
            }

            return rebuilt;
        }

        /// <summary>
        /// Finds a markup by its tag among the default markups then the configured ones.
        /// </summary>
        private static BBCodeMarkup FindMarkup(BBCodeConfig config, string markup)
            => DefaultMarkups.Find(x => x.Markup == markup) ?? config.Markups.Find(x => x.Markup == markup);

        /// <summary>
        /// Split a paragraph text into plain and marked-up segments.
        /// </summary>
        private static List<BBCodeSegment> ParseBBCode(string text, BBCodeConfig config)
        {
            var segments = new List<BBCodeSegment>();
            var cur = 0;

            // TODO: merge consecutive matches having the same markup
            foreach (Match match in _span_regex.Matches(text))
            {
                var markup = match.Groups[1].Value;
                if (FindMarkup(config, markup) == null)
                    continue;

                // Unformatted text before the match
                if (match.Index > cur)
                    segments.Add(new BBCodeSegment(null, text.Substring(cur, match.Index - cur)));

                segments.Add(new BBCodeSegment(markup, match.Groups[2].Value));
                cur = match.Index + match.Length;
            }

            // Unformatted end text, added even when empty
            segments.Add(new BBCodeSegment(null, text.Substring(cur)));
            return segments;
        }

        /// <summary>
        /// Checks whether the paragraph inlines already hold the given segments. Anything else than
        /// plain runs, emoji and valid BBCode spans among the inlines counts as a mismatch.
        /// </summary>
        private static bool HasBBCodeSegments(this Paragraph paragraph, List<BBCodeSegment> segments)
        {
            var current = new List<BBCodeSegment>();
            var plain = new StringBuilder();

            foreach (var inline in paragraph.Inlines)
            {
                if (inline is BBCodeSpan span)
                {
                    if (!span.IsValid)
                        return false;

                    var text = new StringBuilder();
                    foreach (var child in span.Inlines.Where(x => !(x is BBCodeMarkupInline)))
                        if (!AppendText<BBCodeTextInline>(text, child))
                            return false;

                    if (plain.Length > 0)
                        current.Add(new BBCodeSegment(null, plain.ToString()));
                    plain.Clear();
                    current.Add(new BBCodeSegment(span.Markup, text.ToString()));
                }
                else if (!AppendText<Run>(plain, inline))
                    return false;
            }

            current.Add(new BBCodeSegment(null, plain.ToString()));
            return current.SequenceEqual(segments);
        }

        /// <summary>
        /// Appends the text of a run of the exact given type or of an emoji, any other inline is refused.
        /// </summary>
        private static bool AppendText<TRun>(StringBuilder text, Inline inline) where TRun : Run
        {
            if (inline is EmojiInline emoji)
                text.Append(emoji.Text);
            else if (inline.GetType() == typeof(TRun))
                text.Append(((Run)inline).Text);
            else
                return false;

            return true;
        }

        /// <summary>
        /// A stretch of paragraph text, formatted by the markup it names or plain when the markup is null.
        /// </summary>
        private struct BBCodeSegment : IEquatable<BBCodeSegment>
        {
            public string Markup { get; }
            public string Text { get; }

            public BBCodeSegment(string markup, string text)
            {
                Markup = markup;
                Text = text;
            }

            public bool Equals(BBCodeSegment other) => Markup == other.Markup && Text == other.Text;
        }
    }
}
