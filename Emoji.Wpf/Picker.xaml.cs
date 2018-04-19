//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2018 Sam Hocevar <sam@hocevar.net>
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
using System.Windows.Data;
using System.Windows.Markup;

namespace Emoji.Wpf
{
    /// <summary>
    /// Interaction logic for Picker.xaml
    /// </summary>
    public partial class Picker : StackPanel
    {
        public Picker()
        {
            InitializeComponent();
        }

        public IEnumerable<string> EmojiList { get => m_emoji_list; }

        public double FontSize
        {
            get => TextBlock.FontSize;
            set => TextBlock.FontSize = value;
        }

        public event PropertyChangedEventHandler SelectionChanged;

        public string Selection
        {
            get => m_text;
            set
            {
                var old_value = m_text;
                if (value != m_text)
                {
                    m_text = value;
                    var is_disabled = string.IsNullOrEmpty(value);
                    TextBlock.Text = is_disabled ? "???" : value;
                    TextBlock.Opacity = is_disabled ? 0.3 : 1.0;
                    SelectionChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Selection)));
                }
            }
        }

        private string m_text;

        private static IEnumerable<string> m_emoji_list = Data.GetSortedEmoji();

        private void OnEmojiSelected(object sender, RoutedEventArgs e)
        {
            Selection = (sender as Button).DataContext as string;
            Button.IsChecked = false;
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Selection), typeof(string), typeof(Picker), new PropertyMetadata("☺"));
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

