//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017 Sam Hocevar <sam@hocevar.net>
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
using System.Windows.Controls;
using System.Windows.Media;

namespace Emoji.Wpf
{
    /// <summary>
    /// A simple WPF Control that renders an emoji. It can be resized.
    /// </summary>
    public class Image : Canvas
    {
        public Image() {}
        public Image(string text) => Text = text;

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (sizeInfo.WidthChanged || sizeInfo.HeightChanged)
            {
                Width = sizeInfo.WidthChanged ? sizeInfo.NewSize.Width : sizeInfo.NewSize.Height;
                Height = sizeInfo.HeightChanged ? sizeInfo.NewSize.Height : sizeInfo.NewSize.Width;
            }
        }

        protected override void OnRender(DrawingContext dc)
        {
            if (Width > 0 && Height > 0)
            {
                dc.DrawRectangle(Background, null, new Rect(0, 0, Width, Height));

                // Debug the bounding box
                //dc.DrawRectangle(Brushes.Bisque, new Pen(Brushes.LightCoral, 1.0), new Rect(0, 0, Width, Height));

                double total_width = 0.0;
                foreach (ushort glyph in m_glyphs)
                    total_width += m_font.AdvanceWidths[glyph];

                double font_size = Math.Min(Width / total_width,
                                            Height / m_font.Height);
                double startx = 0.5 * (Width - total_width * font_size);
                double starty = font_size * m_font.Baseline;

                // Debug the glyph bounding box
                //dc.DrawRectangle(Brushes.LightYellow, new Pen(Brushes.Orange, 1.0), new Rect(startx, 0, total_width * font_size, m_font.Height * font_size));

                foreach (ushort glyph in m_glyphs)
                {
                    if (glyph == 665 || glyph == 390)
                        continue; // FIXME: just a test; but we need to ignore these one day!
                    dc.PushTransform(new TranslateTransform(startx, starty + m_font.AdvanceHeights[glyph]));
                    m_font.RenderGlyph(dc, glyph, font_size);
                    dc.Pop();
                    startx += m_font.AdvanceWidths[glyph] * font_size;
                }
            }
        }

        private static void TextChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as Image).OnTextChanged((string)e.NewValue);
        }

        private void OnTextChanged(string str)
        {
            if (str.StartsWith("G+"))
            {
                m_glyphs.Clear();
                ushort glyph = 0;
                ushort.TryParse(str.Substring(2), out glyph);
                m_glyphs.Add(glyph);
                return;
            }

            m_glyphs = new List<ushort>(m_font.StringToGlyphIndices(str));

#if false
            // Check whether the Emoji font knows about this codepoint;
            // otherwise, fall back to a simple TextBlock.
            if (!m_font.HasCodepoint(codepoint))
            {
                m_glyph = 0;
                m_textblock.Text = str;
                if (Children.Count == 0)
                    Children.Add(m_textblock);
            }
#endif
            Children.Clear();
        }

        public Brush Foreground
        {
            get => m_textblock.Foreground;
            set => m_textblock.Foreground = value;
        }

        public FontFamily FontFamily
        {
            get => m_textblock.FontFamily;
            set => m_textblock.FontFamily = value;
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(Image), new FrameworkPropertyMetadata("", TextChangedCallback));

        private List<ushort> m_glyphs = new List<ushort>();
        private TextBlock m_textblock = new TextBlock() { TextAlignment = TextAlignment.Center };

        private static ColorTypeface m_font = new ColorTypeface();
    }
}

