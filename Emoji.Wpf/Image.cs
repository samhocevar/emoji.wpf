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

using Typography.TextLayout;

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
            if (m_glyphplanlist.Count > 0 && Width > 0 && Height > 0)
            {
                dc.DrawRectangle(Background, null, new Rect(0, 0, Width, Height));

                // Debug the bounding box
                //dc.DrawRectangle(Brushes.Bisque, new Pen(Brushes.LightCoral, 1.0), new Rect(0, 0, Width, Height));

                double total_width = 0.0;
                for (int i = 0; i < m_glyphplanlist.Count; ++i)
                    total_width = Math.Max(total_width, m_glyphplanlist[i].ExactRight);

                // Compute font size in pixels
                double font_size = Math.Min(Width / total_width,
                                            Height / m_font.Height);
                double startx = 0.5 * (Width - total_width * font_size);
                double starty = font_size * m_font.Baseline;

                // Debug the glyph bounding box
                //dc.DrawRectangle(Brushes.LightYellow, new Pen(Brushes.Orange, 1.0), new Rect(startx, 0, total_width * font_size, m_font.Height * font_size));

                for (int i = 0; i < m_glyphplanlist.Count; ++i)
                {
                    var g = m_glyphplanlist[i];
                    var origin = new Point(startx + g.ExactX * font_size,
                                           starty + g.ExactY * font_size);
                    m_font.RenderGlyph(dc, g.glyphIndex, origin, font_size);
                }
            }
        }

        private static void TextChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as Image).OnTextChanged((string)e.NewValue);
        }

        private void OnTextChanged(string str)
        {
            m_glyphplanlist = m_font.StringToGlyphPlanList(str);

            // Check whether the Emoji font knows about this codepoint;
            // otherwise, fall back to a simple TextBlock.
            for (int i = 0; i < m_glyphplanlist.Count; ++i)
            {
                var g = m_glyphplanlist[i];
                if (g.glyphIndex == 0)
                {
                    m_glyphplanlist.Clear();
                    m_textblock.Text = str;
                    m_textblock.Width = Width;
                    m_textblock.FontSize = Height * 0.75;
                    if (Children.Count == 0)
                        Children.Add(m_textblock);
                    break;
                }
            }

            // If the glyph list is valid, hide our TextBlock child
            if (m_glyphplanlist.Count > 0)
            {
                Children.Clear();
            }
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

        private GlyphPlanList m_glyphplanlist = new GlyphPlanList();
        private TextBlock m_textblock = new TextBlock() { TextAlignment = TextAlignment.Center };

        private static EmojiTypeface m_font = new EmojiTypeface();
    }
}

