//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2020 Sam Hocevar <sam@hocevar.net>
//
//  This program is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Windows;
using System.Windows.Input;

namespace Tiny
{
    /// <summary>
    /// Interaction logic for Tiny.xaml
    /// </summary>
    public partial class TinyWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("Tiny.xaml", UriKind.Relative);
            app.Run();
        }

        public TinyWindow()
        {
            InitializeComponent();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            => DragMove();
    }
}
