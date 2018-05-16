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
        public TextBlock()
        {
            InitializeComponent();

            //m_base_dp.AddValueChanged(this, OnBaseTextChanged);
            //Unloaded += (o, e) =>
            //    m_base_dp.RemoveValueChanged(this, OnBaseTextChanged);
        }

        /// <summary>
        /// Override System.Windows.Controls.TextBox.Text
        /// </summary>
        public new string Text
        {
            get => m_text_dp.GetValue(this) as string;
            set => m_text_dp.SetValue(this, value);
        }

        /// <summary>
        /// Override System.Windows.Controls.TextBox.TextProperty
        /// </summary>
        public static new readonly DependencyProperty TextProperty = DependencyProperty.Register(
                        nameof(Text), typeof(string), typeof(TextBlock),
                        new FrameworkPropertyMetadata("", TextChangedCallback));

        private static void TextChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
            => (o as TextBlock).OnTextChanged(o, new EventArgs());

        private void OnTextChanged(object sender, EventArgs args)
        {
            // Propagate new value for Text (this will rewrite the
            // Inlines due to WPF TextBlock internal behaviour)
            base.Text = Text;

            Inlines.Clear();
            int pos = 0;
            foreach (Match m in EmojiData.MatchMultiple.Matches(Text))
            {
                Inlines.Add(Text.Substring(pos, m.Index - pos));

                var canvas = new EmojiCanvas();
                canvas.Reset(Text.Substring(m.Index, m.Length), FontSize);
                Inlines.Add(new InlineUIContainer(canvas));

                pos = m.Index + m.Length;
            }
            Inlines.Add(Text.Substring(pos));
        }

        private static DependencyPropertyDescriptor m_text_dp =
            DependencyPropertyDescriptor.FromProperty(TextProperty, typeof(TextBlock));
        //private static DependencyPropertyDescriptor m_base_dp =
        //    DependencyPropertyDescriptor.FromProperty(Controls.TextBlock.TextProperty, typeof(TextBlock));
    }

    public class EmojiCanvas : Controls.Canvas
    {
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
                    m_font.RenderGlyph(dc, g.glyphIndex, origin, m_fontsize);
                }
            }
        }

        private string m_text;
        private double m_fontsize;

        private GlyphPlanList m_glyphplanlist = new GlyphPlanList();
        private static EmojiTypeface m_font = new EmojiTypeface();
    }
}
