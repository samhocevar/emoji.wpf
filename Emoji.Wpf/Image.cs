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
        public Image() => UpdateCodepoint(Text);
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

            if (m_codepoint != 0 && Width > 0 && Height > 0)
            {
                double font_size = Math.Min(Width / m_font.Widths[m_codepoint],
                                            Height / m_font.Height);
                m_font.RenderGlyph(dc, m_codepoint, font_size);
            }
        }

        private static void TextChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as Image).UpdateCodepoint((string)e.NewValue);
        }

        private void UpdateCodepoint(string str)
        {
            if (str.Length >= 2 && str[0] >= 0xd800 && str[0] <= 0xdbff)
                m_codepoint = Char.ConvertToUtf32(str[0], str[1]);
            else
                m_codepoint = str.Length == 0 ? 0 : str[0];
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(Image), new FrameworkPropertyMetadata("", TextChangedCallback));

        private int m_codepoint;
        private static ColorTypeface m_font = new ColorTypeface("Segoe UI Emoji");
    }
}

