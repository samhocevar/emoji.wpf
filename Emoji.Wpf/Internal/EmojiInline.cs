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

using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Typography.TextLayout;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    public class EmojiInline : InlineUIContainer
    {
        // Need an empty constructor for serialisation (undo/redo)
        public EmojiInline()
            : base(new Controls.Image())
        {
            // FIXME: not sure TextBottom is the correct value; but Baseline does not work.
            BaselineAlignment = BaselineAlignment.TextBottom;
        }

        public EmojiInline(TextPointer pos)
            : base(new Controls.Image(), pos)
        {
            BaselineAlignment = BaselineAlignment.TextBottom;
        }

        /// <summary>
        /// Redeclare the Child property to prevent it from being serialized.
        /// </summary>
        public new Controls.Image Child
        {
            get => base.Child as Controls.Image;
            private set => base.Child = value;
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(EmojiInline),
            new PropertyMetadata(""));

        protected override bool ShouldSerializeProperty(DependencyProperty dp)
            => dp.Name == nameof(Text) && base.ShouldSerializeProperty(dp);

        protected bool ShouldSerializeChild() => false;

        private struct CacheItem
        {
            internal DrawingImage di;
            internal double width, height;
        };

        private Dictionary<string, CacheItem> m_cache = new Dictionary<string, CacheItem>();

        private void Rebuild()
        {
            // FIXME: How can Child be null in Sample.exe? Investigate.
            if (Child == null)
                return;

            if (string.IsNullOrEmpty(Text))
            {
                Child.Source = null;
                return;
            }

            if (Foreground != Brushes.Black || !m_cache.TryGetValue(Text, out var item))
            {
                var dg = new DrawingGroup();
                using (var dc = dg.Open())
                    RenderText(dc, Text, Foreground, out item.width, out item.height);
                item.di = new DrawingImage(dg);
                item.di.Freeze();

                if (Foreground == Brushes.Black)
                    m_cache[Text] = item;
            }

            Child.Source = item.di;
            Child.Width = item.width * FontSize;
            Child.Height = item.height * FontSize;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            // FIXME: split this into several code paths
            if (e.Property == FontSizeProperty || e.Property == TextProperty
                 || e.Property == ForegroundProperty)
            {
                Rebuild();
            }
        }

        protected void RenderText(DrawingContext dc, string text, Brush brush, out double width, out double height)
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
