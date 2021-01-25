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
    public static class PixelBasedScrollingBehavior 
    {
        public static bool GetIsEnabled(DependencyObject o)
            => (bool)o.GetValue(IsEnabledProperty);

        public static void SetIsEnabled(DependencyObject o, bool val)
            => o.SetValue(IsEnabledProperty, val);

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(PixelBasedScrollingBehavior),
                                                new UIPropertyMetadata(false, IsEnabledChanged));

        private static void IsEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (o is VirtualizingPanel || o is ItemsControl)
            {
                var val = (bool)e.NewValue;
                var t = typeof(Window).Assembly.GetType("System.Windows.Controls.ScrollUnit");
                var f = typeof(VirtualizingPanel).GetField("ScrollUnitProperty",
                            BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                if (t != null && f?.GetValue(null) is DependencyProperty dp)
                {
                    o.SetValue(dp, Enum.Parse(t, val ? "Pixel" : "Item"));
                    return;
                }
                else if (o is VirtualizingPanel)
                {
                    var prop = o.GetType().GetProperty("IsPixelBased",
                                    BindingFlags.NonPublic | BindingFlags.Instance);
                    prop?.SetValue(o, val, null);
                }
            }
        }
    }
}
