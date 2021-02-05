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

using System.Linq;
using System.Windows;
using System.Windows.Media;
using Typography.TextLayout;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    public static class Image
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached("Source", typeof(string), typeof(Image),
                new PropertyMetadata(default(string), OnSourceChanged));

        public static void SetSource(DependencyObject o, string value)
            => o.SetValue(SourceProperty, value);

        public static string GetSource(DependencyObject o)
            => (string)o.GetValue(SourceProperty);

        private static void OnSourceChanged(DependencyObject o,
                                            DependencyPropertyChangedEventArgs e)
        {
            if (o is Controls.Image image)
            {
                var di = new DrawingImage();
                SetSource(di, e.NewValue as string);
                image.Source = di;
            }
            else if (o is DrawingImage di)
            {
                var dg = new DrawingGroup();
                using (var dc = dg.Open())
                    RenderText(dc, e.NewValue as string, Brushes.Black, out var width, out var height);
                di.Drawing = dg;
            }
        }

        internal static void RenderText(DrawingContext dc, string text, Brush brush,
                                        out double width, out double height)
        {
            var font = EmojiData.Typeface;
            var glyphplanlist = font.MakeGlyphPlanList(text);

            // FIXME: height is computed using the Windows typeface object
            // and width using Typography.Openfont. Try to use only one.
            var scale = font.GetScale(0.75); // 1px = 0.75pt
            width = glyphplanlist.Sum(x => x.AdvanceX) * scale;
            height = font.Height;

            // Clip to the render area, and draw a transparent rectangle to avoid
            // automatic resizing. See https://stackoverflow.com/a/8824459/111461
            var area = new Rect(0, 0, width, height);
            dc.PushClip(new RectangleGeometry(area));
            dc.DrawRectangle(Brushes.Transparent, null, area);

            // Render our image
            double startx = 0;
            double starty = font.Baseline;
            bool zwj_hack = false;

            for (int i = 0; i < glyphplanlist.Count; ++i)
            {
                var g = glyphplanlist[i];
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
                    else if (i + 1 < glyphplanlist.Count && glyphplanlist[i + 1].glyphIndex == font.ZwjGlyph)
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
