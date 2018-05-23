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
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

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
            TextProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(
                "",
                (o, e) => (o as TextBlock).TextChangedCallback(e.NewValue as string),
                (o, v) => (o as TextBlock).CoerceTextCallback(v as string)));

            ForegroundProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(
                Brushes.Black,
                (o, e) => (o as TextBlock).ForegroundChangedCallback(e.NewValue as Brush)));
        }

        public TextBlock()
        {
            InitializeComponent();

            //m_base_dp.AddValueChanged(this, OnBaseTextChanged);
            //Unloaded += (o, e) =>
            //    m_base_dp.RemoveValueChanged(this, OnBaseTextChanged);
        }

        private void ForegroundChangedCallback(Brush foreground)
        {
            foreach (var i in Inlines)
            {
                var emoji_inline = i as EmojiInline;
                if (emoji_inline != null)
                    emoji_inline.Foreground = foreground;
            }
        }

        private bool m_recursion_guard = false;

        /// <summary>
        /// Do not coerce the Text property.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string CoerceTextCallback(string text) => text;

        private void TextChangedCallback(String text)
        {
            if (m_recursion_guard)
                return;

            m_recursion_guard = true;
            try
            {
                Inlines.Clear();
                int pos = 0;
                foreach (Match m in EmojiData.MatchMultiple.Matches(text))
                {
                    Inlines.Add(text.Substring(pos, m.Index - pos));
                    Inlines.Add(new EmojiInline()
                    {
                        FallbackBrush = Foreground,
                        Text = text.Substring(m.Index, m.Length),
                        FontSize = FontSize,
                    });

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
}

