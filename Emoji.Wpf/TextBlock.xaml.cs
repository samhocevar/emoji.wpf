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

