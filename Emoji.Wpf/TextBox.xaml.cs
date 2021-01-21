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
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Emoji.Wpf
{
    public partial class TextBox : System.Windows.Controls.TextBox
    {
        public TextBox()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
#if DEBUG
            Console.WriteLine($"Property Changed: {e.Property}");
#endif
            base.OnPropertyChanged(e);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_rtb = Template.FindName("RichTextBox_INTERNAL", this) as RichTextBox;

            // Build a list of TextBox properties that are not inherited from Control. These
            // are the properties we want to bind to our child RichTextBox.
            var exclude = GetReadWritePropertyNames(typeof(System.Windows.Controls.Control));
            var propset = GetReadWritePropertyNames(typeof(TextBox));
            propset.ExceptWith(exclude);

#if DEBUG
            var tmp1 = GetReadWritePropertyNames(typeof(RichTextBox));
            tmp1.ExceptWith(exclude);
            var tmp2 = propset.ToHashSet();
            tmp2.ExceptWith(tmp1);
            tmp1.ExceptWith(propset);

            Console.WriteLine("RichTextBox properties not in TextBox: " + string.Join(" ", tmp1));
            Console.WriteLine("TextBox properties not in RichTextBox: " + string.Join(" ", tmp2));
#endif

            // Add some Control properties that we want to inherit
            propset.UnionWith(new List<string>()
            {
                "Foreground",
            });

            // Iterate over all RichTextBox properties; for each found match, create a
            // two-way binding with one of our properties.
            foreach (var dpd in GetReadWriteProperties(typeof(RichTextBox))
                                   .Where(x => propset.Contains(x.Name))
                                   .Select(x => DependencyPropertyDescriptor.FromProperty(x))
                                   .Where(x => x != null))
            {
                m_rtb.SetBinding(dpd.DependencyProperty, new Binding(dpd.Name)
                {
                    Source = this,
                    Mode = BindingMode.TwoWay,
                });
            }
        }

        private static IEnumerable<PropertyDescriptor> GetReadWriteProperties(Type t)
            => TypeDescriptor.GetProperties(t, new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) })
                             .Cast<PropertyDescriptor>()
                             .Where(x => !x.IsReadOnly);

        private static HashSet<string> GetReadWritePropertyNames(Type t)
            => GetReadWriteProperties(t).Select(x => x.Name).ToHashSet();

        private RichTextBox m_rtb;
    }
}
