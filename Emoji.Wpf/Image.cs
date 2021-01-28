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

using System.Windows;
using System.Windows.Media;
using Typography.TextLayout;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    public static class Image
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached("Source", typeof(string),
                typeof(DependencyObject), new PropertyMetadata(default(string)));

        public static void SetSource(DependencyObject o, string value)
        {
            if (o is Controls.Image image)
            {
                var di = new DrawingImage();
                SetSource(di, value);
                image.Source = di;
            }
            else if (o is DrawingImage di)
            {
                var dg = new DrawingGroup();
                using (var dc = dg.Open())
                    RenderText(dc, value, Brushes.Black, out var width, out var height);
                di.Drawing = dg;
                di.SetValue(SourceProperty, value);
            }
        }

        public static string GetSource(DependencyObject o)
            => (string)o.GetValue(SourceProperty);

        internal static void RenderText(DrawingContext dc, string text, Brush brush,
                                        out double width, out double height)
        {
            var font = EmojiData.Typeface;
            var glyphplanlist = font.MakeGlyphPlanList(text);
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

            // Clip to the render area, and draw a transparent rectangle to avoid
            // automatic resizing. See https://stackoverflow.com/a/8824459/111461
            var area = new Rect(0, 0, width, height);
            dc.PushClip(new RectangleGeometry(area));
            dc.DrawRectangle(Brushes.Transparent, null, area);

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

                    foreach (var p in font.MakePaths(g.glyphIndex, new Point(xpos, ypos), size, brush))
                        dc.DrawGeometry(p.Fill, null, p.Data);

                    if (zwj_hack)
                        ++i;
                    else
                        startx += g.AdvanceX * scale;
                }
            }
        }
    }
}
