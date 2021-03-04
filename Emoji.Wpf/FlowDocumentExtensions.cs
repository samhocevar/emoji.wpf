//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
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
    public class EmojiOptions
    {
        public bool ColonSyntax { get; set; }
        public bool ColorBlend { get; set; }
    }

    public static class FlowDocumentExtensions
    {
        private static readonly Regex ColonSyntaxRegex = new Regex("^:([-a-z]+):");

        static public void ColorizeEmojis(this FlowDocument document)
        {
            ColorizeEmojis(document, new EmojiOptions());
        }

        static public void ColorizeEmojis(this FlowDocument document, EmojiOptions emojiOptions)
        {
            var dummy = document.ContentStart;
            ColorizeEmojis(document, emojiOptions, dummy);
        }
        static public TextPointer ColorizeEmojis(this FlowDocument document, TextPointer caretPosition)
            => ColorizeEmojis(document, new EmojiOptions(), caretPosition);

        static public TextPointer ColorizeEmojis(this FlowDocument document, EmojiOptions emojiOptions, TextPointer caretPosition)
        {
            // options
            var ColonSyntax = emojiOptions.ColonSyntax;
            var ColorBlend = emojiOptions.ColorBlend;

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
                else if (ColonSyntax && replace_range.Text == ":")
                {
                    var end = next.GetNextContextPosition(LogicalDirection.Forward);
                    var match = ColonSyntaxRegex.Match(new TextRange(cur, end).Text);
                    if (match.Success && EmojiData.LookupByName.TryGetValue(match.Groups[1].Value.Replace("-", " "), out var emoji))
                    {
                        replace_text = emoji.Text;
                        next = cur.GetPositionAtCharOffset(match.Value.Length);
                        replace_range = new TextRange(cur, next);
                    }
                }

                if (replace_text != null)
                {
                    // Preserve caret position in case of replacement
                    bool caret_was_next = cur.CompareTo(caretPosition) < 0 && next.CompareTo(caretPosition) >= 0;

                    var font_size = replace_range.GetPropertyValue(TextElement.FontSizeProperty);
                    var foreground = replace_range.GetPropertyValue(TextElement.ForegroundProperty);

                    // Delete the Unicode characters and insert our emoji inline instead.
                    replace_range.Text = "";
                    Inline inline = new EmojiInline(cur)
                    {
                        FontSize = (double)(font_size ?? document.FontSize),
                        Foreground = ColorBlend ? (Brush)(foreground ?? document.Foreground) : Brushes.Black,
                        Text = replace_text,
                    };

                    next = inline.ContentEnd;
                    if (caret_was_next)
                        caretPosition = next;
                }

                cur = next;
            }

            return caretPosition;
        }
    }
}
