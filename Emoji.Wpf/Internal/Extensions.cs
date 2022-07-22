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
using System.Windows.Documents;

namespace Emoji.Wpf
{
    internal static class Extensions
    {
        /// <summary>
        /// Advance a TextPointer to the nth character
        /// </summary>
        public static TextPointer GetPositionAtCharOffset(this TextPointer p, int offset)
        {
            var fallback = offset > 0 ? p.DocumentEnd : p.DocumentStart;
            while (offset != 0 && p != null)
            {
                var dir = offset > 0 ? LogicalDirection.Forward : LogicalDirection.Backward;
                if (p.GetPointerContext(dir) == TextPointerContext.Text)
                {
                    var text = p.GetTextInRun(dir);
                    if (text.Length >= Math.Abs(offset))
                        return p.GetPositionAtOffset(offset);
                    offset -= Math.Sign(offset) * text.Length;
                }
                p = p.GetNextContextPosition(dir);
            }
            return p ?? fallback;
        }

        /// <summary>
        /// Gets all elements of a given type between two <see cref="TextPointer"/>s
        /// </summary>
        public static IEnumerable<T> GetElements<T>(this TextRange text_range)
        {
            for (var p = text_range.Start; p != null && p.CompareTo(text_range.End) < 0; p = p.GetNextContextPosition(LogicalDirection.Forward))
                if (p.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.ElementStart)
                    if (p.GetAdjacentElement(LogicalDirection.Forward) is T element)
                        yield return element;
        }
    }
}
