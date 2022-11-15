//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2021 Sam Hocevar <sam@hocevar.net>
//
//  This program is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Tests
{
    /// <summary>
    /// Interaction logic for Tests.xaml
    /// </summary>
    public partial class TestsWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("Tests.xaml", UriKind.Relative);
            app.Run();
        }

        public TestsWindow()
        {
            InitializeComponent();

            WidthTest.ItemsSource = new List<string>
            {
                string.Concat(Enumerable.Repeat("😄", 47)),
                string.Concat(Enumerable.Repeat("🎀", 49)),
                string.Concat(Enumerable.Repeat("🍊", 52)),
                string.Concat(Enumerable.Repeat("👨🏻‍👩🏿‍👧🏽‍👦🏽‍‍", 33)),
            };
        }
    }
}
