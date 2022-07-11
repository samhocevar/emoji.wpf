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
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    [DebuggerDisplay(@"\{BBCodeMarkupInline: {Text}\}")]
    public class BBCodeMarkupInline : Run
    {
        public BBCodeMarkupInlineType Type { get; set; }
        public string Markup { get; set; }

        private static readonly SolidColorBrush _defaultForeground
            = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBBBBBB"));

        private bool _is_visible = false;
        public bool IsVisible
        {
            get => _is_visible;
            set
            {
                if (_is_visible != value)
                {
                    _is_visible = value;
                    Text = _is_visible ? $"[{(Type == BBCodeMarkupInlineType.Closing ? "/" : "")}{Markup}]" : "";
                }
            }
        }

        public BBCodeMarkupInline()
            : base()
        {
            Foreground = _defaultForeground;
        }

        public BBCodeMarkupInline(BBCodeMarkup markup, BBCodeMarkupInlineType type)
            : base()
        {
            Markup = markup.Markup;
            Type = type;
            Foreground = _defaultForeground;
            IsVisible = true;
        }
    }

    public enum BBCodeMarkupInlineType
    {
        Opening,
        Closing
    }
}
