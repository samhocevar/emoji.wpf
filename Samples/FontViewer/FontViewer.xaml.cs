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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using Emoji.Wpf;

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

        public FontViewerWindow() => InitializeComponent();

        public class MyEmoji
        {
            public string UnicodeText { get; private set; }
            public string UnicodeSeq { get; private set; }
            public string GlyphSeq { get; private set; }
            public string EmojiName { get; private set; }

            public MyEmoji(string s, string emojiname)
            {
                List<int> codepoints = new List<int>();
                for (int i = 0; i < s.Length; )
                {
                    int codepoint = i + 1 < s.Length ? char.ConvertToUtf32(s, i) : s[i];
                    codepoints.Add(codepoint);
                    i += codepoint >= 0x10000 ? 2 : 1;
                }

                UnicodeText = s;
                UnicodeSeq = string.Join(" ", codepoints.Select(x => $"U+{x:X4}"));
                GlyphSeq = string.Join(" ", EmojiData.Typeface.MakeGlyphIndexList(s).Select(x => $"#{x}"));
                EmojiName = emojiname;
            }
        }

        public override void EndInit()
        {
            base.EndInit();

            EmojiFontList.ItemsSource = new ObservableCollection<MyEmoji>(
                EmojiData.AllEmoji.Where(x => x.Renderable).Select(x => new MyEmoji(x.Text, x.Name)));
        }
    }
}

