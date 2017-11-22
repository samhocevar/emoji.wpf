//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System.Collections.Generic;

namespace Emoji.Wpf
{
    public static partial class Data
    {
        public class EmojiSorter : IComparer<string>
        {
            public EmojiSorter(Dictionary<int, int> order)
            {
                m_order = order;
            }

            private Dictionary<int, int> m_order;

            private static int StringToCodepoint(string s)
            {
                if (s.Length >= 2 && s[0] >= 0xd800 && s[0] <= 0xdbff)
                    return char.ConvertToUtf32(s[0], s[1]);
                return s.Length == 0 ? 0 : s[0];
            }

            private int Order(string s)
            {
                int n = StringToCodepoint(s);
                return m_order.TryGetValue(n, out n) ? n : s[0];
            }

            int IComparer<string>.Compare(string x, string y)
            {
                int ret = Order(x).CompareTo(Order(y));
                return ret == 0 ? x.CompareTo(y) : ret;
            }
        }

        public static IDictionary<string, string> MsEmoji { get => (IDictionary<string, string>)m_ms_emoji; }

        public static IEnumerable<string> GetSortedEmoji()
        {
            List<string> emoji_sequences = new List<string>();
            foreach (string key in MsEmoji.Keys)
                emoji_sequences.Add(key);

            Dictionary<int, int> char_weights = new Dictionary<int, int>();
            for (int i = 0; i < m_ordering.Count; ++i)
                char_weights.Add(m_ordering[i], 0x100000 + i);

            emoji_sequences.Sort(new EmojiSorter(char_weights));
            return emoji_sequences;
        }
    }
}

