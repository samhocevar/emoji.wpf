//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2021 Sam Hocevar <sam@hocevar.net>
//                   2021 Victor Irzak <victor.irzak@zomp.com>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System.Windows;
using System.Windows.Documents;

namespace Emoji.Wpf
{
    public static class Behaviors
    {
        /// <summary>
        /// Using a DependencyProperty as the backing store for EmojiRendering.
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty EmojiRenderingProperty =
            DependencyProperty.RegisterAttached("EmojiRendering", typeof(bool), typeof(Behaviors),
                                                new UIPropertyMetadata(false, EmojiRenderingChanged));

        public static bool GetEmojiRendering(DependencyObject o)
            => (bool)o.GetValue(EmojiRenderingProperty);

        public static void SetEmojiRendering(DependencyObject o, bool value)
            => o.SetValue(EmojiRenderingProperty, value);

        private static void EmojiRenderingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FlowDocument doc && (bool)e.NewValue)
                doc.Loaded += FlowDocument_Loaded;
        }

        private static void FlowDocument_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is FlowDocument doc)
                doc.SubstituteGlyphs();
        }
    }
}
