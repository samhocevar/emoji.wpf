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
using System.Windows.Data;

namespace Emoji.Wpf
{
    public partial class TextBox : System.Windows.Controls.TextBox
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private static IEnumerable<PropertyDescriptor> GetReadWriteProperties(Type t)
            => TypeDescriptor.GetProperties(t, new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) })
                             .Cast<PropertyDescriptor>()
                             .Where(x => !x.IsReadOnly);

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Build a list of TextBox properties that are not inherited from Control. These
            // are the properties we want to bind to our child RichTextBox.
            var exclude = GetReadWriteProperties(typeof(System.Windows.Controls.Control))
                             .Select(x => x.Name).ToHashSet();
            var propset = GetReadWriteProperties(typeof(TextBox))
                             .Select(x => x.Name).ToHashSet();
            propset.ExceptWith(exclude);

            // Iterate over all RichTextBox properties; for each found match, create a
            // two-way binding with the TextBox element.
            var rtb = Template.FindName("PART_RichTextBox", this) as RichTextBox;
            foreach (var dpd in GetReadWriteProperties(typeof(RichTextBox))
                                 .Where(x => propset.Contains(x.Name))
                                 .Select(x => DependencyPropertyDescriptor.FromProperty(x))
                                 .Where(x => x != null))
            {
                Binding binding = new Binding(dpd.Name);
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                rtb.SetBinding(dpd.DependencyProperty, binding);
            }
        }
    }
}
