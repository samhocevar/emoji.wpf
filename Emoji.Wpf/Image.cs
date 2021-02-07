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
            // and width using Typography.OpenFont. Try to use only one.
            var scale = font.GetScale(0.75); // 1px = 0.75pt
            width = glyphplanlist.Where(g => g.glyphIndex != font.ZwjGlyph)
                                 .Sum(g => g.AdvanceX) * scale;
            if (EmojiData.RenderingFallbackHack)
            {
                width -= glyphplanlist.WithPreviousAndNext()
                                      .Where(t => t.Next.glyphIndex == font.ZwjGlyph)
                                      .Sum(t => t.Current.AdvanceX) * scale;
            }
            height = font.Height;

            // Clip to the render area, and draw a transparent rectangle to avoid
            // automatic resizing. See https://stackoverflow.com/a/8824459/111461
            var area = new Rect(0, 0, width, height);
            dc.PushClip(new RectangleGeometry(area));
            dc.DrawRectangle(Brushes.Transparent, null, area);

            // Render our image
            int startx = 0;

            foreach (var t in glyphplanlist.WithPreviousAndNext())
            {
                var g = t.Current;
                var xpos = (startx + g.OffsetX) * scale;
                var ypos = font.Baseline + g.OffsetY * scale;
                double ds = 1.0;

                if (g.glyphIndex == font.ZwjGlyph)
                    continue;

                if (EmojiData.RenderingFallbackHack)
                {
                    if (t.Next.glyphIndex == font.ZwjGlyph)
                    {
                        ds = 0.75;
                        ypos -= 0.25 / ds;
                    }
                    else if (t.Previous.glyphIndex == font.ZwjGlyph)
                    {
                        ds = 0.75;
                        xpos += 0.25 / ds;
                    }
                }

                dc.PushTransform(new MatrixTransform(ds, 0, 0, ds, xpos, ypos));

                foreach (var p in font.MakePaths(g.glyphIndex, brush))
                    dc.DrawGeometry(p.Fill, null, p.Data);

                dc.Pop();

                if (EmojiData.RenderingFallbackHack && t.Next.glyphIndex == font.ZwjGlyph)
                    continue;

                startx += g.AdvanceX;
            }
        }
    }
}
