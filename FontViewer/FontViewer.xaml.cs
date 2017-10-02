//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017 Sam Hocevar <sam@hocevar.net>
//
//  This program is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace FontViewer
{
    /// <summary>
    /// Interaction logic for FontViewer.xaml
    /// </summary>
    public partial class FontViewerWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("FontViewer.xaml", UriKind.Relative);
            app.Run();
        }

        public class Glyph
        {
            public string UnicodeDesc { get; set; }
            public string UnicodeText { get; set; }

            public Glyph(int codepoint)
            {
                UnicodeDesc = string.Format("U+{0:X4}", codepoint);
                UnicodeText = char.ConvertFromUtf32(codepoint).ToString();
            }
        }

        public FontViewerWindow()
        {
            InitializeComponent();

            var glyph_list = new ObservableCollection<Glyph>();
            var font = new Emoji.Wpf.ColorTypeface("Segoe UI Emoji");
            for (int ch = 0x20; ch < 0x7f; ++ch)
                glyph_list.Add(new Glyph(ch));
            foreach (int code in font.CharacterToGlyphMap.Keys)
                glyph_list.Add(new Glyph(code));

            EmojiFontList.ItemsSource = glyph_list;
        }
    }
}

