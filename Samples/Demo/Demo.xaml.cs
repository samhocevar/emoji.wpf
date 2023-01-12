//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2023 Sam Hocevar <sam@hocevar.net>
//
//  This program is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Demo
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class DemoWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("Demo.xaml", UriKind.Relative);
            app.Run();
        }

        public DemoWindow()
        {
            InitializeComponent();

            var brushes = new Dictionary<string, Brush>();
            foreach (var p in typeof(Brushes).GetProperties(BindingFlags.Static | BindingFlags.Public))
                brushes[p.Name] = (Brush)p.GetValue(null, null);
            ColorPicker.ItemsSource = brushes;

            EditorPicker.Picked += (o, e) =>
                EmojiRichTextBox.CaretPosition.InsertTextInRun(e.Emoji);
        }
    }
}

