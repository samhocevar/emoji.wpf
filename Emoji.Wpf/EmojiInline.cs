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
using System.Windows.Media.Imaging;
using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    public class EmojiInline : InlineUIContainer
    {
        // Need an empty constructor for serialisation (undo/redo)
        public EmojiInline()
        {
            // FIXME: not sure this is the correct value; but Baseline does not work.
            BaselineAlignment = BaselineAlignment.TextBottom;
            Child = new EmojiCanvas();
        }

        /// <summary>
        /// Redeclare the Child property to prevent it from being serialized.
        /// </summary>
        public new EmojiCanvas Child
        {
            get => base.Child as EmojiCanvas;
            private set => base.Child = value;
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

        protected override bool ShouldSerializeProperty(DependencyProperty dp)
            => dp.Name == nameof(Text) && base.ShouldSerializeProperty(dp);

        protected bool ShouldSerializeChild() => false;

        private bool m_dirty;
        private BitmapSource m_bitmap;

        private static EmojiTypeface m_font = EmojiData.Typeface;

        public void Render(DrawingContext dc)
        {
            if (m_dirty)
            {
                // If FontSize < 32 (aka. 2**5) we render at a larger resolution
                double scale = Math.Pow(2.0, Math.Max(0.0, Math.Ceiling(5.0 - Math.Log(FontSize, 2.0))));
                m_bitmap = EmojiRenderer.RenderBitmap(Text ?? "", FontSize * scale, FallbackBrush);
                // Try to compute our own widget size
                Child.Width = Math.Floor(m_bitmap.Width / scale);
                Child.Height = Math.Floor(m_bitmap.Height / scale);
                Child.InvalidateVisual();
                m_dirty = false;
            }

            if (Child.ActualWidth > 0 && Child.ActualHeight > 0)
            {
                var rect = new Rect(0, 0, Child.ActualWidth, Child.ActualHeight);

                dc.DrawRectangle(Background, null, rect);
#if false
                // Debug the bounding box
                dc.DrawRectangle(Brushes.Bisque, new Pen(Brushes.LightCoral, 1.0), rect);
#endif
                dc.DrawImage(m_bitmap, rect);
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            // FIXME: split this into two different code paths
            if (e.Property == FontSizeProperty || e.Property == TextProperty)
            {
                Child?.InvalidateVisual();
                m_dirty = true;
            }
            else if (e.Property == FallbackBrushProperty)
                Child?.InvalidateVisual();
        }

        public bool Invalid { get; private set; }
    }

    public class EmojiCanvas : Controls.Canvas
    {
        protected override void OnRender(DrawingContext dc)
            => (Parent as EmojiInline)?.Render(dc);

        // FIXME: reimplement this?
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

