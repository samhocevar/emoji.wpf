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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emoji.Wpf.BBCode
{
    /// <summary>
    /// Configuration class for an Emoji RichTextBox supporting BBCode
    /// </summary>
    public class BBCodeConfig
    {
        /// <summary>
        /// List of BBCode markup definitions.
        /// </summary>
        public List<BBCodeMarkup> Markups { get; set; }

        /// <summary>
        /// Scale factor for markups font size.
        /// </summary>
        public double MarkupFontScale { get; set; } = 0.7;
    }
}
