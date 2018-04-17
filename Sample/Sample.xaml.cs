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
using System.Windows;

namespace Sample
{
    /// <summary>
    /// Interaction logic for Sample.xaml
    /// </summary>
    public partial class SampleWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("Sample.xaml", UriKind.Relative);
            app.Run();
        }

        public SampleWindow() => InitializeComponent();
    }
}

