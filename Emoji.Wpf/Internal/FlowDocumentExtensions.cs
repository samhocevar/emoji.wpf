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

using System.Text.RegularExpressions;
using System.Windows.Documents;
#if DEBUG
#endif
using System.Windows.Media;

namespace Emoji.Wpf
{
    internal class EmojiOptions
    {
        public bool ColonSyntax { get; set; }
        public bool ColorBlend { get; set; }
    }

    internal static class FlowDocumentExtensions
    {
        private static readonly Regex ColonSyntaxRegex = new Regex("^:([-a-z]+):");

        internal static void ColorizeEmojis(this FlowDocument document)
            => ColorizeEmojis(document, new EmojiOptions {});

        internal static void ColorizeEmojis(this FlowDocument document, TextPointer caret)
            => ColorizeEmojis(document, new EmojiOptions {}, caret);

        internal static void ColorizeEmojis(this FlowDocument document, EmojiOptions options)
            => ColorizeEmojis(document, options, document.ContentStart);

        internal static TextPointer ColorizeEmojis(this FlowDocument document, EmojiOptions options,
                                                   TextPointer caret)
        {
            var colon_syntax = options.ColonSyntax;
            var color_blend = options.ColorBlend;

            TextPointer cur = document.ContentStart;
            while (cur.CompareTo(document.ContentEnd) < 0)
            {
                TextPointer next = cur.GetNextInsertionPosition(LogicalDirection.Forward);
                if (next == null)
                    break;

                string replace_text = null;
                var replace_range = new TextRange(cur, next);
                if (EmojiData.MatchOne.IsMatch(replace_range.Text))
                {
                    // We found an emoji, but it’s possible that GetNextInsertionPosition
                    // did not pick enough characters and the emoji sequence is actually
                    // longer. To avoid this, we look up to 50 characters ahead and retry
                    // the match.
                    var lookup = next.GetNextContextPosition(LogicalDirection.Forward);
                    if (cur.GetOffsetToPosition(lookup) > 50)
                        lookup = cur.GetPositionAtOffset(50, LogicalDirection.Forward);
                    var match = EmojiData.MatchOne.Match(new TextRange(cur, lookup).Text);
                    while (match.Length > replace_range.Text.Length)
                    {
                        next = next.GetNextInsertionPosition(LogicalDirection.Forward);
                        if (next == null)
                            break;
                        replace_range = new TextRange(cur, next);
                    }

                    replace_text = match.Value;
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
                    bool caret_was_next = cur.CompareTo(caret) < 0 && next.CompareTo(caret) >= 0;

                    var font_size = replace_range.GetPropertyValue(TextElement.FontSizeProperty);
                    var foreground = replace_range.GetPropertyValue(TextElement.ForegroundProperty);

                    // Delete the Unicode characters and insert our emoji inline instead.
                    replace_range.Text = "";
                    Inline inline = new EmojiInline(cur)
                    {
                        FontSize = (double)(font_size ?? document.FontSize),
                        Foreground = color_blend ? (Brush)(foreground ?? document.Foreground) : Brushes.Black,
                        Text = replace_text,
                    };

                    next = inline.ContentEnd;
                    if (caret_was_next)
                        caret = next;
                }

                cur = next;
            }

            return caret;
        }
    }
}
