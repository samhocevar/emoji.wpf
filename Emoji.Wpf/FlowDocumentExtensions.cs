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
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf
{
    [Flags]
    public enum SubstituteOptions
    {
        None = 0,
        ColonSyntax = 1,
        ColorBlend = 2,
    }

    public static class FlowDocumentExtensions
    {
        private static readonly Regex ColonSyntaxRegex = new Regex("^:([-a-z]+):");

        /// <summary>
        /// Substitute emoji glyphs with emoji inlines in a FlowDocument
        /// </summary>
        public static void SubstituteGlyphs(this FlowDocument document)
            => SubstituteGlyphs(document, SubstituteOptions.None);

        public static void SubstituteGlyphs(this FlowDocument document, SubstituteOptions options)
            => SubstituteGlyphs(document.ContentStart, document.ContentEnd, document.FontSize,
                                document.Foreground, document.Parent, options);

        /// <summary>
        /// Substitute emoji glyphs with emoji inlines in a text Run
        /// </summary>
        public static void SubstituteGlyphs(this Run run)
            => SubstituteGlyphs(run, SubstituteOptions.None);

        public static void SubstituteGlyphs(this Run run, SubstituteOptions options)
            => SubstituteGlyphs(run.ContentStart, run.ContentEnd, run.FontSize,
                                run.Foreground, run.Parent, options);

        private static void SubstituteGlyphs(TextPointer range_start, TextPointer range_end, double default_font_size,
                                             Brush default_foreground, System.Windows.DependencyObject parent,
                                             SubstituteOptions options)
        {
            // If our parent is a RichTextBox, try to retain the caret position
            RichTextBox rtb = parent as RichTextBox;

            var colon_syntax = (options & SubstituteOptions.ColonSyntax) != 0;
            var color_blend = (options & SubstituteOptions.ColorBlend) != 0;

            TextPointer caret = rtb?.CaretPosition;
            TextPointer cur = range_start;
            while (cur.CompareTo(range_end) < 0)
            {
                TextPointer next = cur.GetNextInsertionPosition(LogicalDirection.Forward);
                if (next == null)
                    break;

                string replace_text = null;
                var replace_range = new TextRange(cur, next);
                if (replace_range.Text.Length > 0 && EmojiData.MatchStart.Contains(replace_range.Text[0]))
                {
                    // GetNextInsertionPosition() is not reliable to find emoji because
                    // it sometimes stops in the middle of a valid sequence (for flags
                    // that do not use ZWJ, or for some recent skin tone variations).
                    // To fix this, we look up to 50 characters ahead.
                    var lookup = next.GetNextContextPosition(LogicalDirection.Forward);
                    if (cur.GetOffsetToPosition(lookup) > 50)
                        lookup = cur.GetPositionAtOffset(50, LogicalDirection.Forward);
                    var match = EmojiData.MatchOne.Match(new TextRange(cur, lookup).Text);
                    if (match.Success)
                    {
                        while (match.Length > replace_range.Text.Length)
                        {
                            next = next.GetNextInsertionPosition(LogicalDirection.Forward);
                            if (next == null)
                                break;
                            replace_range = new TextRange(cur, next);
                        }

                        replace_text = match.Value;
                    }
                }
                else if (colon_syntax && replace_range.Text == ":")
                {
                    var end = next.GetNextContextPosition(LogicalDirection.Forward);
                    var match = ColonSyntaxRegex.Match(new TextRange(cur, end).Text);
                    if (match.Success && EmojiData.LookupByName.TryGetValue(match.Groups[1].Value, out var emoji))
                    {
                        replace_text = match.Value;
                        next = cur.GetPositionAtCharOffset(match.Value.Length);
                        replace_range = new TextRange(cur, next);
                    }
                }

                if (replace_text != null)
                {
                    // Preserve caret position in case of replacement
                    bool caret_was_next = caret != null && cur.CompareTo(caret) < 0 && next.CompareTo(caret) >= 0;

                    var font_size = replace_range.GetPropertyValue(TextElement.FontSizeProperty);
                    var foreground = replace_range.GetPropertyValue(TextElement.ForegroundProperty);

                    // Delete the Unicode characters and insert our emoji inline instead.
                    replace_range.Text = "";
                    Inline inline = new EmojiInline(cur)
                    {
                        FontSize = (double)(font_size ?? default_font_size),
                        Foreground = color_blend ? (Brush)(foreground ?? default_foreground) : Brushes.Black,
                        Text = replace_text,
                    };

                    next = inline.ContentEnd;
                    if (caret_was_next)
                        caret = next;
                }

                cur = next;
            }

            if (rtb != null)
                rtb.CaretPosition = caret;
        }
    }
}
