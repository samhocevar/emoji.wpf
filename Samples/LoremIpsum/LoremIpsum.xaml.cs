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

using Emoji.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace LoremIpsum
{
    /// <summary>
    /// Interaction logic for LoremIpsum.xaml
    /// </summary>
    public partial class LoremIpsumWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("LoremIpsum.xaml", UriKind.Relative);
            app.Run();
        }

        public LoremIpsumWindow()
        {
            InitializeComponent();
        }

        public override void EndInit()
        {
            base.EndInit();

            ListBox.ItemsSource = Enumerable
                .Range(1, 1000)
                .Select(i => new Item() { Text = $"{i}. {LoremIpsum(m_rng.Next(20, 200))}." })
                .ToList();
        }

        private string LoremIpsum(int length)
        {
            var sb = new StringBuilder();
            sb.Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RandomWord));
            while (sb.Length < length)
            {
                sb.Append((m_rng.Next() & 7) <= 0 ? ", " : " ");
                sb.Append((m_rng.Next() & 7) <= 2 ? RandomEmoji : RandomWord);
            }
            return sb.ToString();
        }

        private string RandomWord => m_words[m_rng.Next(m_words.Count)];
        private string RandomEmoji => m_emoji[m_rng.Next(m_emoji.Count)].Text;

        public struct Item
        {
            public string Text { get; set; }
        }

        private static Random m_rng = new Random();
        private static List<EmojiData.Emoji> m_emoji = EmojiData.AllEmoji.Where(e => e.Renderable).ToList();
        private static List<string> m_words = new Regex($"[- ,.\r\n]+").Split(@"Lorem ipsum dolor sit amet,
            consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
            consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat
            nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt
            mollit anim id est laborum.".ToLower()).ToList();
    }
}
