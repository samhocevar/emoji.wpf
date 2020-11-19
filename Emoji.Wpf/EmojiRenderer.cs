//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2020 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Typography.TextLayout;

namespace Emoji.Wpf
{
    public static class EmojiRenderer
    {
        // This is enough to store all emojis at size 32×32
        public static long MaxCachedBitmaps = 4000;
        public static long MaxCachedPixels = 5120000;

        public static BitmapSource RenderBitmap(string text, double font_size, Brush fallback)
        {
            // If the cache is too large, remove the first element repeatedly until it’s OK.
            while (m_cache.Count >= MaxCachedBitmaps || m_cached_pixels >= MaxCachedPixels)
            {
                var it = m_cache.GetEnumerator();
                it.MoveNext();
                m_cached_pixels -= ((RenderKey)it.Key).Pixels;
                m_cache.RemoveAt(0);
            }

            // Query the cache for this bitmap and render it if not found
            BitmapSource ret;
            var key = new RenderKey() { Text = text, FontSize = font_size, Fallback = fallback };
            if (m_cache.Contains(key))
            {
                ret = m_cache[key] as BitmapSource;
                m_cache.Remove(key);
                m_cache[key] = ret;
                ++m_cache_hits;
            }
            else
            {
                m_cache[key] = ret = RenderBitmapInternal(text, font_size, fallback);
                m_cached_pixels += key.Pixels;
                ++m_cache_misses;
            }

            return ret;
        }

        private struct RenderKey
        {
            public string Text;
            public double FontSize;
            public Brush Fallback;

            public long Pixels => (long)Math.Pow(Math.Ceiling(FontSize), 2.0);
        };

        /// <summary>
        /// A cache of bitmaps, indexed by source string, font size, and fallback brush.
        /// </summary>
        private static OrderedDictionary m_cache = new OrderedDictionary();

        private static long m_cached_pixels = 0;

        private static long m_cache_hits = 0;
        private static long m_cache_misses = 0;

        public static BitmapSource RenderBitmapInternal(string text, double font_size, Brush fallback)
        {
            var font = EmojiData.Typeface;
            var glyphplanlist = font.MakeGlyphPlanList(text ?? "");
            var glyphplansequence = new GlyphPlanSequence(glyphplanlist);

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
            var bitmap = new RenderTargetBitmap((int)Math.Max(1.0, Math.Ceiling(width)),
                                                (int)Math.Max(1.0, Math.Ceiling(height)),
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
