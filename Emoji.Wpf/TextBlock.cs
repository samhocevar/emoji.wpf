//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2021 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using Stfu.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    /// <summary>
    /// A simple WPF text control that is emoji-aware.
    /// </summary>
    public class TextBlock : Controls.TextBlock, IEmojiControl
    {
        static TextBlock()
        {
            TextProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(
                (string)Controls.TextBlock.TextProperty.GetMetadata(typeof(Controls.TextBlock)).DefaultValue,
                (o, e) => (o as TextBlock)?.OnTextChanged(e.NewValue as string)));

            ForegroundProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(
                (Brush)ForegroundProperty.GetMetadata(typeof(Controls.TextBlock)).DefaultValue,
                (o, e) => (o as TextBlock)?.OnForegroundChanged(e.NewValue as Brush)));

            FontSizeProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(
                (double)FontSizeProperty.GetMetadata(typeof(Controls.TextBlock)).DefaultValue,
                (o, e) => (o as TextBlock)?.OnFontSizeChanged((double)e.NewValue)));

            TextWrappingProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(
                (TextWrapping)TextWrappingProperty.GetMetadata(typeof(Controls.TextBlock)).DefaultValue,
                (o, e) => (o as TextBlock)?.OnTextWrappingChanged((TextWrapping)e.NewValue)));
        }

        /// <summary>
        /// Implement the same constructor as Controls.TextBlock
        /// </summary>
        public TextBlock() => Init();

        /// <summary>
        /// Implement the same constructor as Controls.TextBlock
        /// </summary>
        public TextBlock(Inline inline) : base(inline) => Init();

        private void Init()
        {
            // If the client does not use the Text property, nothing will notify us that
            // inlines have been created and may need glyph substitution, so we do it
            // manually on load.
            Loaded += (o, e) =>
                Inlines.OfType<Run>().ToList().ForEach(r => r.SubstituteGlyphs());
        }

        /// <summary>
        /// Override System.Windows.Controls.TextBlock.Text using our own dependency
        /// property. This is necessary because we do not want the parent callbacks
        /// to run, ever, and OverrideMetadata does not properly hide them.
        /// Also note that calling GetValue/SetValue is a lot faster when used directly
        /// on the DependencyPropertyDescriptor because it bypasses the reflection code.
        /// </summary>
        public new string Text
        {
            get => m_text_dpd.GetValue(this) as string;
            set => m_text_dpd.SetValue(this, value);
        }

        /// <summary>
        /// Override System.Windows.Controls.TextBlock.TextProperty
        /// </summary>
        public static new readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBlock));

        public bool ColorBlend
        {
            get => (bool)GetValue(ColorBlendProperty);
            set => SetValue(ColorBlendProperty, value);
        }

        public static readonly DependencyProperty ColorBlendProperty =
             DependencyProperty.Register(nameof(ColorBlend), typeof(bool), typeof(TextBlock),
                 new PropertyMetadata(false, (o, e) => (o as TextBlock)?.OnColorBlendChanged((bool)e.NewValue)));

        public IEnumerable<EmojiInline> EmojiInlines
            => Inlines.OfType<EmojiInline>();

        private void OnTextChanged(string text)
            => RecomputeInlines(text, TextWrapping);

        private void OnTextWrappingChanged(TextWrapping wrapping)
            => RecomputeInlines(Text, wrapping);

        private void RecomputeInlines(string text, TextWrapping wrapping)
        {
            Inlines.Clear();
            if (string.IsNullOrEmpty(text))
                return;

            // We could use EmojiData.MatchMultiple when wrapping is disabled, but for
            // now EmojiInline is unable to render a mix of emoji GlyphRuns and our
            // custom XAML data.
            int pos = 0;
            foreach (Match m in EmojiData.MatchOne.Matches(text))
            {
                if (m.Index != pos)
                    Inlines.Add(text.Substring(pos, m.Index - pos));

                Inlines.Add(new EmojiInline
                {
                    FontSize = FontSize,
                    Foreground = ColorBlend ? Foreground : Brushes.Black,
                    Text = text.Substring(m.Index, m.Length),
                });

                pos = m.Index + m.Length;
            }

            if (pos != text.Length)
                Inlines.Add(text.Substring(pos));
        }

        private void OnColorBlendChanged(bool color_blend)
            => EmojiInlines.ForAll(e => e.Foreground = color_blend ? Foreground : Brushes.Black);

        private void OnForegroundChanged(Brush brush)
            => EmojiInlines.ForAll(e => e.Foreground = ColorBlend ? brush : Brushes.Black);

        private void OnFontSizeChanged(double size)
            => EmojiInlines.ForAll(e => e.FontSize = size);

        private static readonly DependencyPropertyDescriptor m_text_dpd =
            DependencyPropertyDescriptor.FromProperty(TextProperty, typeof(TextBlock));
    }
}

