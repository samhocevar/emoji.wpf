//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//                   2022 Charles Spitzer <charles.spitzer@dont-nod.com>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    /// <summary>
    /// Class encapsulating BBCode markup properties.
    /// </summary>
    public class BBCodeMarkup
    {
        public string Name { get; set; }
        public string Markup { get; set; }
        public Color? Foreground { get; set; }
        public Color? Background { get; set; }
        public FontWeight? FontWeight { get; set; }
        public FontStyle? FontStyle { get; set; }
        public TextDecorationCollection TextDecorations { get; set; }
        public string Shortcut { get; set; } = null;

        public BBCodeMarkupInline CreateMarkupInline(BBCodeMarkupInlineType type) => new BBCodeMarkupInline(this, type);

        public BBCodeTextInline CreateTextInline(string text)
        {
            var result = new BBCodeTextInline(text);

            if (Foreground.HasValue)
                result.Foreground = new SolidColorBrush(Foreground.Value);
            if (Background.HasValue)
                result.Background = new SolidColorBrush(Background.Value);
            if (FontWeight.HasValue)
                result.FontWeight = FontWeight.Value;
            if (FontStyle.HasValue)
                result.FontStyle = FontStyle.Value;
            if (TextDecorations != null)
                result.TextDecorations = TextDecorations;

            return result;
        }
    }
}
