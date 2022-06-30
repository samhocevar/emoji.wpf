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

namespace Emoji.Wpf.BBCode
{
    [DebuggerDisplay(@"\{BBCodeTextInline: {Text}\}")]
    public class BBCodeTextInline : Run
    {
        public BBCodeTextInline()
            : base()
        {
        }

        public BBCodeTextInline(string text)
        {
            Text = text;
        }
    }
}
