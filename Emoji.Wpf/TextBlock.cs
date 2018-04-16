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
    /// A backwards-compatible alias
    /// </summary>
    public class Image : TextBlock
    {
    }

    /// <summary>
    /// A simple WPF Control that renders an emoji. It can be resized.
    /// </summary>
    public class TextBlock : Canvas
    {
        public TextBlock()
        {
            SnapsToDevicePixels = true;
        }

        public TextBlock(string text)
        {
            SnapsToDevicePixels = true;
            Text = text;
        }

        protected override void OnRender(DrawingContext dc)
        {
            if (m_glyphplanlist.Count > 0 && ActualWidth > 0 && ActualHeight > 0)
            {
                dc.DrawRectangle(Background, null, new Rect(0, 0, ActualWidth, ActualHeight));

                // Debug the bounding box
                //var bounds = new Rect(0, 0, ActualWidth, ActualHeight);
                //dc.DrawRectangle(Brushes.Bisque, new Pen(Brushes.LightCoral, 1.0), bounds);

                // Compute font size in pixels
                double total_width = m_glyphplanlist.AccumAdvanceX;
                double font_size = Math.Min(ActualWidth / total_width,
                                            ActualHeight / FontSize);
                double startx = 0;
                double starty = FontSize * m_font.Baseline;

                // Debug the glyph bounding box
                //dc.DrawRectangle(Brushes.LightYellow, new Pen(Brushes.Orange, 1.0), new Rect(startx, 0, total_width * font_size, m_font.Height * font_size));

                for (int i = 0; i < m_glyphplanlist.Count; ++i)
                {
                    var g = m_glyphplanlist[i];
                    var origin = new Point(Math.Round(startx + g.ExactX * 0.75),
                                           Math.Round(starty + g.ExactY * 0.75));
                    m_font.RenderGlyph(dc, g.glyphIndex, origin, FontSize);
                }
            }
        }

        private static void TextChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as TextBlock).OnTextChanged((string)e.NewValue);
        }

        private void OnTextChanged(string str)
        {
            m_glyphplanlist = m_font.StringToGlyphPlanList(str, FontSize);

            // Check whether the Emoji font knows about this codepoint;
            // otherwise, fall back to a simple TextBlock.
            for (int i = 0; i < m_glyphplanlist.Count; ++i)
            {
                var g = m_glyphplanlist[i];
                if (g.glyphIndex == 0)
                {
                    m_glyphplanlist.Clear();
                    m_textblock.Text = str;
                    if (Width >= 0)
                        m_textblock.Width = Width;
                    if (Height >= 0)
                        m_textblock.FontSize = Height * 0.75;
                    if (Children.Count == 0)
                        Children.Add(m_textblock);
                    break;
                }
            }

            // If the glyph list is valid, hide our TextBlock child
            // and try to compute our own widget size
            if (m_glyphplanlist.Count > 0)
            {
                Children.Clear();
                // FIXME: I am not sure why the math below works
                Height = FontSize / 0.75; // 1 pixel = 0.75pt
                Width = m_glyphplanlist.AccumAdvanceX * 0.75;
            }
        }

        public Brush Foreground
        {
            get => m_textblock.Foreground;
            set => m_textblock.Foreground = value;
        }

        public double FontSize
        {
            get => m_textblock.FontSize;
            set { m_textblock.FontSize = value; OnTextChanged(Text); }
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
            nameof(Text), typeof(string), typeof(TextBlock), new FrameworkPropertyMetadata("", TextChangedCallback));

        private GlyphPlanList m_glyphplanlist = new GlyphPlanList();
        private System.Windows.Controls.TextBlock m_textblock
            = new System.Windows.Controls.TextBlock() { TextAlignment = TextAlignment.Center };

        private static EmojiTypeface m_font = new EmojiTypeface();
    }
}

