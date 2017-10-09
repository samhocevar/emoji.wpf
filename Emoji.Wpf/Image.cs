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
            // Debug the bounding box
            //dc.DrawRectangle(Brushes.Bisque, new Pen(Brushes.LightCoral, 1.0), new Rect(0, 0, Width, Height));

            if (m_codepoint == 0 && m_glyph == 0)
            {
                m_textblock.FontSize = Math.Min(Width, Height) * 0.75;
                m_textblock.Width = Width;
                m_textblock.Height = Height;
                m_textblock.Background = Background;
            }
            else if (Width > 0 && Height > 0)
            {
                ushort glyph = m_glyph > 0 ? m_glyph : m_font.CharacterToGlyphIndex(m_codepoint);
                double font_size = Math.Min(Width / m_font.Widths[glyph],
                                            Height / m_font.Height);
                double startx = 0.5 * (Width - m_font.Widths[glyph] * font_size);
                double starty = font_size * m_font.Baseline;
                dc.DrawRectangle(Background, null, new Rect(0, 0, Width, Height));
                dc.PushTransform(new TranslateTransform(startx, starty));
                m_font.RenderGlyph(dc, glyph, font_size);
                dc.Pop();
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
                m_codepoint = 0;
                m_glyph = 0;
                ushort.TryParse(str.Substring(2), out m_glyph);
                return;
            }

            int codepoint = 0;

            // Find the codepoint for the string.
            if (str.Length >= 2 && str[0] >= 0xd800 && str[0] <= 0xdbff)
                codepoint = Char.ConvertToUtf32(str[0], str[1]);
            else
                codepoint = str.Length == 0 ? 0 : str[0];

            // Check whether the Emoji font knows about this codepoint;
            // otherwise, fall back to a simple TextBlock.
            if (m_font.HasCodepoint(codepoint))
            {
                m_codepoint = codepoint;
                m_glyph = m_font.CharacterToGlyphIndex(codepoint);
                Children.Clear();
                return;
            }
            else
            {
                m_codepoint = 0;
                m_glyph = 0;
                m_textblock.Text = str;
                if (Children.Count == 0)
                    Children.Add(m_textblock);
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

        private int m_codepoint;
        private ushort m_glyph;
        private TextBlock m_textblock = new TextBlock() { TextAlignment = TextAlignment.Center };

        private static ColorTypeface m_font = new ColorTypeface("Segoe UI Emoji");
    }
}

