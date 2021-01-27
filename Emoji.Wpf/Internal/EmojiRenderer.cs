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

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Typography.TextLayout;

namespace Emoji.Wpf
{
    internal static class EmojiRenderer
    {
        internal static IEnumerable<Path> CreatePaths(string text, Brush brush, out double width, out double height)
        {
            var ret = new List<Path>();
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
            var scale = font.GetScale(1.0) * 0.75;
            width = glyphplansequence.CalculateWidth() * scale;
            height = 1.0 / 0.75;

#if false
            font_size *= Math.Min(bitmap.Width / width, bitmap.Height / height);
#endif

            // Render our image
            if (glyphplansequence.Count > 0 && width > 0 && height > 0)
            {
                var visual = new DrawingVisual();
                double startx = 0;
                double starty = font.Baseline;
                bool zwj_hack = false;

                for (int i = 0; i < glyphplansequence.Count; ++i)
                {
                    var g = glyphplansequence[i];
                    var size = 1.0;
                    var xpos = startx + g.OffsetX * scale;
                    var ypos = starty + g.OffsetY * scale;

                    if (EmojiData.RenderingFallbackHack)
                    {
                        if (zwj_hack)
                        {
                            zwj_hack = false;
                            xpos += size * 0.25;
                            size *= 0.75;
                        }
                        else if (i + 1 < glyphplansequence.Count && glyphplansequence[i + 1].glyphIndex == font.ZwjGlyph)
                        {
                            zwj_hack = true;
                            ypos -= size * 0.25;
                            size *= 0.75;
                        }
                    }

                    ret.AddRange(font.MakePaths(g.glyphIndex, new Point(xpos, ypos), size, brush));

                    if (zwj_hack)
                        ++i;
                    else
                        startx += g.AdvanceX * scale;
                }
            }

            return ret;
        }
    }
}
