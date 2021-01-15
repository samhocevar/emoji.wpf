//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Generic;

namespace Emoji.Wpf
{
    internal static class Extensions
    {
        internal static void ForAll<T>(this IEnumerable<T> elements, Action<T> fn)
        {
            foreach (var e in elements)
                fn(e);
        }
    }
}
