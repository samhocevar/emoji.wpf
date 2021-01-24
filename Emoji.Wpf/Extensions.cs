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
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Emoji.Wpf
{
    internal static class Extensions
    {
        internal static void ForAll<T>(this IEnumerable<T> elements, Action<T> fn)
        {
            foreach (var e in elements)
                fn(e);
        }

        internal static HashSet<T> ToHashSet<T>(this IEnumerable<T> elements,
                                                IEqualityComparer<T> comparer = null)
            => new HashSet<T>(elements, comparer);
    }

    internal class BoolInverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is bool b ? !b : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => value is bool b ? !b : value;
    }
}
