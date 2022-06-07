﻿using System;
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
        public readonly string Name;
        public readonly string Markup;
        public readonly Color? Foreground;
        public readonly FontWeight? FontWeight;
        public readonly FontStyle? FontStyle;

        public BBCodeMarkup(string name, string markup, Color? foreground = null, FontWeight? font_weight = null, FontStyle? font_style = null)
        {
            Name = name;
            Markup = markup;
            Foreground = foreground;
            FontWeight = font_weight;
            FontStyle = font_style;
        }
    }
}