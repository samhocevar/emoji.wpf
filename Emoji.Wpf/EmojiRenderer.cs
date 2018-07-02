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
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Emoji.Wpf
{
    public static class EmojiRenderer
    {
        public static BitmapSource RenderBitmap(string text, double font_size, Brush fallback)
        {
            var font = EmojiData.Typeface;
            var glyphplanlist = font.StringToGlyphPlanList(text ?? "", font_size);

#if false
            // Check whether the Emoji font knows about all codepoints;
            // otherwise, set Invalid to true.
            bool invalid = false;
            for (int i = 0; i < glyphplanlist.Count; ++i)
                if (glyphplanlist[i].glyphIndex == 0)
                    invalid = true;
#endif

            // FIXME: I am not sure why the math below works
            var width = glyphplanlist.AccumAdvanceX * 0.75;
            var height = font_size / 0.75;
            var bitmap = new RenderTargetBitmap((int)Math.Ceiling(width), (int)Math.Ceiling(height),
                                                96, 96, PixelFormats.Pbgra32);

#if false
            font_size *= Math.Min(bitmap.Width / width, bitmap.Height / height);
#endif

            // Render our image
            if (glyphplanlist.Count > 0 && width > 0 && height > 0)
            {
                var visual = new DrawingVisual();
                var dc = visual.RenderOpen();
                double startx = 0;
                double starty = font_size * font.Baseline;

                for (int i = 0; i < glyphplanlist.Count; ++i)
                {
                    var g = glyphplanlist[i];
                    var origin = new Point(Math.Round(startx + g.ExactX * 0.75),
                                           Math.Round(starty + g.ExactY * 0.75));
                    font.RenderGlyph(dc, g.glyphIndex, origin, font_size, fallback);
                }

                dc.Close();
                bitmap.Render(visual);
            }

            return bitmap;
        }
    }
}
