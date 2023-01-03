//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2023 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using Stfu.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Emoji.Wpf
{
    /// <summary>
    /// The Emoji.Wpf.TextBox class inherits from the WPF TextBox, but it actually uses an
    /// Emoji.Wpf.RichTextBox internally, through the template system. This is because only
    /// a RichTextBox can render colour images.
    /// The trick is then to forward all property changes to the container.
    /// FIXME: the "Text" property changes ignore UpdateSourceTrigger=PropertyChanged and
    /// act as if the default UpdateSourceTrigger=LostFocus was still in use.
    /// </summary>
    public partial class TextBox : System.Windows.Controls.TextBox
    {
        public TextBox()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Property Changed: {e.Property}");
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

            System.Diagnostics.Debug.WriteLine("RichTextBox properties not in TextBox: " + string.Join(" ", tmp1));
            System.Diagnostics.Debug.WriteLine("TextBox properties not in RichTextBox: " + string.Join(" ", tmp2));
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
