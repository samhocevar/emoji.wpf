//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2018 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Typography.TextLayout;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    /// <summary>
    /// A backwards compatibility alias
    /// </summary>
    public class Image : TextBlock { }

    /// <summary>
    /// A simple WPF Control that renders an emoji. It can be resized.
    /// </summary>
    public partial class TextBlock : Controls.TextBlock
    {
        static TextBlock()
        {
            TextProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata("", TextChangedCallback));
            ForegroundProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(Brushes.Black, ForegroundChangedCallback));
        }

        public TextBlock()
        {
            InitializeComponent();

            //m_base_dp.AddValueChanged(this, OnBaseTextChanged);
            //Unloaded += (o, e) =>
            //    m_base_dp.RemoveValueChanged(this, OnBaseTextChanged);
        }

        private static void TextChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
            => (o as TextBlock).OnTextChanged(e.NewValue as String, (o as TextBlock).Foreground);

        private static void ForegroundChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
            => (o as TextBlock).OnTextChanged((o as TextBlock).Text, e.NewValue as Brush);

        private bool m_recursion_guard = false;

        private void OnTextChanged(String newText, Brush newForeground)
        {
            if (m_recursion_guard)
                return;

            m_recursion_guard = true;
            String text = newText ?? Text;
            Inlines.Clear();
            try
            {
                int pos = 0;
                foreach (Match m in EmojiData.MatchMultiple.Matches(text))
                {
                    Inlines.Add(text.Substring(pos, m.Index - pos));

                    var canvas = new EmojiCanvas { FallbackBrush = newForeground };
                    canvas.Reset(text.Substring(m.Index, m.Length), FontSize);
                    Inlines.Add(new InlineUIContainer(canvas));

                    pos = m.Index + m.Length;
                }
                Inlines.Add(text.Substring(pos));
            }
            finally
            {
                m_recursion_guard = false;
            }
        }
    }

    public class EmojiCanvas : Controls.Canvas
    {
        public Brush FallbackBrush
        {
            get => (Brush)GetValue(FallbackBrushProperty);
            set => SetValue(FallbackBrushProperty, value);
        }

        public static readonly DependencyProperty FallbackBrushProperty = DependencyProperty.Register(
            nameof(FallbackBrush), typeof(Brush), typeof(EmojiCanvas),
            new PropertyMetadata(Brushes.Black));

        public void Reset(string text, double fontsize)
        {
            if (text == m_text && fontsize == m_fontsize)
                return;

            m_text = text;
            m_fontsize = fontsize;

            m_glyphplanlist = m_font.StringToGlyphPlanList(m_text ?? "", m_fontsize);

            // Check whether the Emoji font knows about all codepoints;
            // otherwise, set Invalid to true.
            Invalid = false;
            for (int i = 0; i < m_glyphplanlist.Count; ++i)
                if (m_glyphplanlist[i].glyphIndex == 0)
                    Invalid = true;

            // Try to compute our own widget size
            // FIXME: I am not sure why the math below works
            Height = m_fontsize / 0.75; // 1 pixel = 0.75pt
            Width = m_glyphplanlist.AccumAdvanceX * 0.75;
            InvalidateVisual();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == FallbackBrushProperty)
                InvalidateVisual();
        }

        public bool Invalid { get; private set; }

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
                                            ActualHeight / m_fontsize);
                double startx = 0;
                double starty = m_fontsize * m_font.Baseline;

                // Debug the glyph bounding box
                //dc.DrawRectangle(Brushes.LightYellow, new Pen(Brushes.Orange, 1.0), new Rect(startx, 0, total_width * font_size, m_font.Height * font_size));

                for (int i = 0; i < m_glyphplanlist.Count; ++i)
                {
                    var g = m_glyphplanlist[i];
                    var origin = new Point(Math.Round(startx + g.ExactX * 0.75),
                                           Math.Round(starty + g.ExactY * 0.75));
                    m_font.RenderGlyph(dc, g.glyphIndex, origin, m_fontsize, FallbackBrush);
                }
            }
        }

        // FIXME: reimplement this
#if false
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            m_fontsize = ((Parent as InlineUIContainer).Parent as EmojiElement).FontSize;
            // FIXME: compute the total length
            Width = m_fontsize * m_font.AdvanceWidths[m_font.CharacterToGlyphIndex(m_codepoint)];
            Height = m_fontsize * m_font.Height;
        }
#endif

        private string m_text;
        private double m_fontsize;

        private GlyphPlanList m_glyphplanlist = new GlyphPlanList();
        private static EmojiTypeface m_font = new EmojiTypeface();
    }
}
