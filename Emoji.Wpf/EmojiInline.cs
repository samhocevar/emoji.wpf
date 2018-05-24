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
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Typography.TextLayout;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    public class EmojiInline : InlineUIContainer
    {
        public EmojiInline()
        {
            // FIXME: not sure this is the correct value; but Baseline does not work.
            BaselineAlignment = BaselineAlignment.TextBottom;
            Child = m_canvas = new EmojiCanvas(this);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Brush FallbackBrush
        {
            get => (Brush)GetValue(FallbackBrushProperty);
            set => SetValue(FallbackBrushProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(EmojiInline),
            new PropertyMetadata(""));

        public static readonly DependencyProperty FallbackBrushProperty = DependencyProperty.Register(
            nameof(FallbackBrush), typeof(Brush), typeof(EmojiInline),
            new PropertyMetadata(Brushes.Black));

        private bool m_dirty;
        private GlyphPlanList m_glyphplanlist = new GlyphPlanList();
        private EmojiCanvas m_canvas;

        private static EmojiTypeface m_font = new EmojiTypeface();

        public void Reset()
        {
            m_glyphplanlist = m_font.StringToGlyphPlanList(Text ?? "", FontSize);

            // Check whether the Emoji font knows about all codepoints;
            // otherwise, set Invalid to true.
            Invalid = false;
            for (int i = 0; i < m_glyphplanlist.Count; ++i)
                if (m_glyphplanlist[i].glyphIndex == 0)
                    Invalid = true;

            // Try to compute our own widget size
            // FIXME: I am not sure why the math below works
            m_canvas.Height = FontSize / 0.75; // 1 pixel = 0.75pt
            m_canvas.Width = m_glyphplanlist.AccumAdvanceX * 0.75;
            m_canvas.InvalidateVisual();
        }

        public void Render(DrawingContext dc)
        {
            if (m_dirty)
            {
                Reset();
                m_dirty = false;
            }

            if (m_glyphplanlist.Count > 0 && m_canvas.ActualWidth > 0 && m_canvas.ActualHeight > 0)
            {
                var rect = new Rect(0, 0, m_canvas.ActualWidth, m_canvas.ActualHeight);
                dc.DrawRectangle(Background, null, rect);

                // Debug the bounding box
                //rect = new Rect(0, 0, ActualWidth, ActualHeight);
                //dc.DrawRectangle(Brushes.Bisque, new Pen(Brushes.LightCoral, 1.0), rect);

                // Compute font size in pixels
                double total_width = m_glyphplanlist.AccumAdvanceX;
                double font_size = Math.Min(m_canvas.ActualWidth / total_width,
                                            m_canvas.ActualHeight / FontSize);
                double startx = 0;
                double starty = FontSize * m_font.Baseline;

                // Debug the glyph bounding box
                //rect = new Rect(startx, 0, total_width * font_size, m_font.Height * font_size);
                //dc.DrawRectangle(Brushes.LightYellow, new Pen(Brushes.Orange, 1.0), rect);

                for (int i = 0; i < m_glyphplanlist.Count; ++i)
                {
                    var g = m_glyphplanlist[i];
                    var origin = new Point(Math.Round(startx + g.ExactX * 0.75),
                                           Math.Round(starty + g.ExactY * 0.75));
                    m_font.RenderGlyph(dc, g.glyphIndex, origin, FontSize, FallbackBrush);
                }
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            // FIXME: split this into two different code paths
            if (e.Property == FontSizeProperty || e.Property == TextProperty)
            {
                m_canvas.InvalidateVisual();
                m_dirty = true;
            }
            else if (e.Property == FallbackBrushProperty)
                m_canvas.InvalidateVisual();
        }

        public bool Invalid { get; private set; }
    }

    public class EmojiCanvas : Controls.Canvas
    {
        public EmojiCanvas(EmojiInline parent)
        {
            m_parent = parent;
        }

        protected override void OnRender(DrawingContext dc) => m_parent.Render(dc);

        private EmojiInline m_parent;

        // FIXME: reimplement this
#if false
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            //FontSize = (Parent as EmojiInline).FontSize;
            // FIXME: compute the total length
            //Width = FontSize * m_font.AdvanceWidths[m_font.CharacterToGlyphIndex(m_codepoint)];
            //Height = FontSize * m_font.Height;
        }
#endif
    }
}

