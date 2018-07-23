//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2018 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Emoji.Wpf
{
    public static class EmojiRenderer
    {
        public static BitmapSource RenderBitmap(string text, double font_size, Brush fallback)
        {
            var key = new RenderKey() { Text = text, FontSize = font_size, Fallback = fallback };
            if (!m_cache.TryGetValue(key, out var ret))
                m_cache[key] = ret = RenderBitmapInternal(text, font_size, fallback);
            return ret;
        }

        private struct RenderKey
        {
            public string Text;
            public double FontSize;
            public Brush Fallback;
        };

        /// <summary>
        /// A cache of bitmaps, indexed by source string, font size, and fallback
        /// brush. This may grow large with some projects, so in the future we
        /// should probably add an expiration mechanism.
        /// </summary>
        private static IDictionary<RenderKey, BitmapSource> m_cache = new Dictionary<RenderKey, BitmapSource>();

        public static BitmapSource RenderBitmapInternal(string text, double font_size, Brush fallback)
        {
            var font = EmojiData.Typeface;
            var glyphplansequence = font.MakeGlyphPlanSequence(text ?? "");

#if false
            // Check whether the Emoji font knows about all codepoints;
            // otherwise, set Invalid to true.
            bool invalid = false;
            for (int i = 0; i < glyphplanlist.Count; ++i)
                if (glyphplanlist[i].glyphIndex == 0)
                    invalid = true;
#endif

            // FIXME: I am not sure why the math below works
            var scale = font.GetScale(font_size) * 0.75;
            var width = glyphplansequence.CalculateWidth() * scale;
            var height = font_size / 0.75;
            var bitmap = new RenderTargetBitmap((int)Math.Ceiling(width), (int)Math.Ceiling(height),
                                                96, 96, PixelFormats.Pbgra32);

#if false
            font_size *= Math.Min(bitmap.Width / width, bitmap.Height / height);
#endif

            // Render our image
            if (glyphplansequence.Count > 0 && width > 0 && height > 0)
            {
                var visual = new DrawingVisual();
                var dc = visual.RenderOpen();
                double startx = 0;
                double starty = font_size * font.Baseline;

                for (int i = 0; i < glyphplansequence.Count; ++i)
                {
                    var g = glyphplansequence[i];
                    var origin = new Point(Math.Round(startx + g.OffsetX * scale),
                                           Math.Round(starty + g.OffsetY * scale));
                    font.RenderGlyph(dc, g.glyphIndex, origin, font_size, fallback);
                    startx += g.AdvanceX * scale;
                }

                dc.Close();
                bitmap.Render(visual);
            }

            return bitmap;
        }

    }
}
