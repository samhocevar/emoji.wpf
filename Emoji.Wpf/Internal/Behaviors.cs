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
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Emoji.Wpf
{
    // Code is inspired by https://stackoverflow.com/a/17431815/111461
    internal static class PixelBasedScrollingBehavior
    {
        internal static bool GetIsEnabled(DependencyObject o)
            => (bool)o.GetValue(IsEnabledProperty);

        internal static void SetIsEnabled(DependencyObject o, bool val)
            => o.SetValue(IsEnabledProperty, val);

        internal static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(PixelBasedScrollingBehavior),
                                                new UIPropertyMetadata(false, IsEnabledChanged));

        private static void IsEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (o is VirtualizingPanel || o is ItemsControl)
            {
                var val = (bool)e.NewValue;
                var enum_type = typeof(Window).Assembly.GetType("System.Windows.Controls.ScrollUnit");
                var field_flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
                var field = typeof(VirtualizingPanel).GetField("ScrollUnitProperty", field_flags);
                if (enum_type != null && field?.GetValue(null) is DependencyProperty dp)
                {
                    o.SetValue(dp, Enum.Parse(enum_type, val ? "Pixel" : "Item"));
                }
                else if (o is VirtualizingPanel)
                {
                    var prop_flags = BindingFlags.NonPublic | BindingFlags.Instance;
                    var prop = o.GetType().GetProperty("IsPixelBased", prop_flags);
                    prop?.SetValue(o, val, null);
                }
            }
        }
    }
}
