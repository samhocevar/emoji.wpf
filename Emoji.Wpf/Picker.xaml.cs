//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2020 Sam Hocevar <sam@hocevar.net>
//
//  This program is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace Emoji.Wpf
{
    public class EmojiPickedEventArgs : EventArgs
    {
        public EmojiPickedEventArgs() { }
        public EmojiPickedEventArgs(string emoji) => Emoji = emoji;

        public string Emoji;
    }

    public delegate void EmojiPickedEventHandler(object sender, EmojiPickedEventArgs e);

    /// <summary>
    /// Interaction logic for Picker.xaml
    /// </summary>
    public partial class Picker : StackPanel
    {
        public Picker()
        {
            InitializeComponent();
        }

        public IList<EmojiData.Group> EmojiGroups => EmojiData.AllGroups;

        public double FontSize
        {
            get => TextBlock.FontSize;
            set => TextBlock.FontSize = value;
        }

        public event PropertyChangedEventHandler SelectionChanged;

        public event EmojiPickedEventHandler Picked;

        private static void OnSelectionPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            (source as Picker)?.OnSelectionChanged(e.NewValue as string);
        }

        public string Selection
        {
            get => (string)GetValue(SelectionProperty);
            set => SetValue(SelectionProperty, value);
        }

        private void OnSelectionChanged(string s)
        {
            var is_disabled = string.IsNullOrEmpty(s);
            TextBlock.Text = is_disabled ? "???" : s;
            TextBlock.Opacity = is_disabled ? 0.3 : 1.0;
            SelectionChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Selection)));
        }

        private void OnEmojiPicked(object sender, RoutedEventArgs e)
        {
            if (m_current_toggle != null)
            {
                m_current_toggle.IsChecked = false;
                m_current_toggle.Focusable = false;
                m_current_toggle = null;
            }

            var emoji = (sender as Control).DataContext as EmojiData.Emoji;
            if (emoji.VariationList.Count == 0 || sender is Button)
            {
                Selection = emoji.Text;
                Button_INTERNAL.IsChecked = false;
                e.Handled = true;
                Picked?.Invoke(this, new EmojiPickedEventArgs(Selection));
            }

            if (sender is ToggleButton && emoji.VariationList.Count > 0)
            {
                m_current_toggle = sender as ToggleButton;
            }
        }

        private ToggleButton m_current_toggle;

        public static readonly DependencyProperty SelectionProperty = DependencyProperty.Register(
            nameof(Selection), typeof(string), typeof(Picker), new FrameworkPropertyMetadata("☺", OnSelectionPropertyChanged));

        private void OnPopupKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && sender is Popup)
            {
                (sender as Popup).IsOpen = false;
                e.Handled = true;
            }
        }

        private void OnPopupLoaded(object sender, RoutedEventArgs e)
        {
            var child = (sender as Popup).Child;
            IInputElement old_focus = null;
            child.Focusable = true;
            child.IsVisibleChanged += (o, ea) =>
            {
                if (child.IsVisible)
                {
                    old_focus = Keyboard.FocusedElement;
                    Keyboard.Focus(child);
                }
            };

            (sender as Popup).Closed += (o, ea) => Keyboard.Focus(old_focus);
        }
    }

    public class BoolInverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is bool ? !(bool)value : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => value is bool ? !(bool)value : value;
    }
}

