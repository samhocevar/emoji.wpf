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
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            public string UnicodeText { get; set; }
            public string UnicodeSeq { get; set; }
            public string EmojiName { get; set; }

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
                UnicodeSeq = string.Join(" ", codepoints.ConvertAll(x => string.Format("U+{0:X4}", x)).ToArray());
                EmojiName = emojiname;
            }
        }

        public override void EndInit()
        {
            base.EndInit();

            var emoji_list = new ObservableCollection<MyEmoji>();
            var font = new EmojiTypeface();

            foreach (var emoji in Emoji.Wpf.Data.Emoji.ListAll)
                emoji_list.Add(new MyEmoji(emoji.Text, emoji.Name));

            EmojiFontList.ItemsSource = emoji_list;
        }
    }
}

