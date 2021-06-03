//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace Emoji.Wpf
{
    public static class EmojiData
    {
        public static EmojiTypeface Typeface { get; private set; }

        public static IEnumerable<Emoji> AllEmoji
            => from g in AllGroups
               from e in g.EmojiList
               select e;

        public static IList<Group> AllGroups { get; private set; }

        public static IDictionary<string, Emoji> LookupByText { get; private set; }
            = new Dictionary<string, Emoji>();
        public static IDictionary<string, Emoji> LookupByName { get; private set; }
            = new Dictionary<string, Emoji>();

        public static Regex MatchOne { get; private set; }
        public static HashSet<char> MatchStart { get; private set; }
            = new HashSet<char>();

        public static bool EnableZwjRenderingFallback { get; set; } = true;

        public static bool EnableSubPixelRendering { get; set; } = false;

        public static bool EnableWindowsStyleFlags
        {
            get => m_use_custom_flags.GetValueOrDefault(!Typeface.HasFlagGlyphs);
            set => m_use_custom_flags = value;
        }

        private static bool? m_use_custom_flags = null;

        // FIXME: should we lazy load this? If the user calls Load() later, then
        // this first Load() call will have been for nothing.
        static EmojiData() => Load();

        public static void Load()
            => Load(null);

        public static void Load(string font_name)
        {
            Typeface = new EmojiTypeface(font_name);
            ParseEmojiList();

            // Insert Microsoft’s custom hacker emoji (in reverse order)
            RegisterEmoji("hacker cat",  "🐱\u200d💻", after: "pouting cat");
            RegisterEmoji("dino cat",    "🐱\u200d🐉", after: "pouting cat");
            RegisterEmoji("ninja cat",   "🐱\u200d👤", after: "pouting cat");
            RegisterEmoji("astro cat",   "🐱\u200d🚀", after: "pouting cat");
            RegisterEmoji("hipster cat", "🐱\u200d👓", after: "pouting cat");
            RegisterEmoji("stunt cat",   "🐱\u200d🏍", after: "pouting cat");

            // Some custom flags that we like to have
            RegisterEmoji("anarchy flag", "🏴️‍🅰️", after: "transgender-flag");
            RegisterEmoji("flag: Basque Country", "🏴󠁥󠁳󠁰󠁶󠁿", after: "flag-bosnia-herzegovina");
            RegisterEmoji("flag: Bretagne", "🏴󠁦󠁲󠁢󠁲󠁥󠁿", after: "flag-brazil");
            RegisterEmoji("flag: Catalonia", "🏴󠁥󠁳󠁣󠁴󠁿", after: "flag-canada");
        }

        public class Emoji
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public bool Renderable { get; set; }
            public bool HasVariations => VariationList.Count > 0;

            public Group Group => SubGroup.Group;
            public SubGroup SubGroup;

            public IList<Emoji> VariationList { get; } = new List<Emoji>();
        }

        public class SubGroup
        {
            public string Name { get; set; }
            public Group Group;

            public IList<Emoji> EmojiList { get; } = new List<Emoji>();
        }

        public class Group
        {
            public string Name { get; set; }
            public string Icon => SubGroups.FirstOrDefault()?.EmojiList.FirstOrDefault()?.Text;

            public IList<SubGroup> SubGroups { get; } = new List<SubGroup>();

            public int EmojiCount
                => SubGroups.Select(s => s.EmojiList.Count).Sum();

            public IEnumerable<IEnumerable<Emoji>> EmojiChunkList
                => EmojiList.Chunk(8);

            public IEnumerable<Emoji> EmojiList
                => from s in SubGroups
                   from e in s.EmojiList
                   select e;
        }

        public static void RegisterEmoji(string name, string sequence, string after)
        {
            if (!LookupByName.TryGetValue(ToColonSyntax(after), out var predecessor))
                predecessor = AllEmoji.Last();

            var entry = new Emoji
            {
                Name = name,
                Text = sequence,
                SubGroup = predecessor.SubGroup,
            };
            var list = predecessor.SubGroup.EmojiList;
            list.Insert(list.IndexOf(predecessor) + 1, entry);

            LookupByName[ToColonSyntax(name)] = entry;
            LookupByText[sequence] = entry;
            MatchStart.Add(sequence[0]);

            m_match_one_string = sequence.Replace("\ufe0f", "\ufe0f?") + "|" + m_match_one_string;
            MatchOne = new Regex("(" + m_match_one_string + ")");
        }

        public static void RegisterDrawing(string sequence, Drawing dg)
        {
            m_custom_drawings[sequence] = dg;
            EmojiInline.InvalidateCache(sequence);
        }

        internal static Drawing GetDrawing(string sequence)
            => m_custom_drawings.TryGetValue(sequence, out var ret) ? ret : null;

        private static Dictionary<string, Drawing> m_custom_drawings
            = new Dictionary<string, Drawing>();

        private static string m_match_one_string;

        // FIXME: this could be read directly from emoji-test.txt.gz
        private static List<string> SkinToneComponents = new List<string>
        {
            "🏻", // light skin tone
            "🏼", // medium-light skin tone
            "🏽", // medium skin tone
            "🏾", // medium-dark skin tone
            "🏿", // dark skin tone
        };

        private static List<string> HairStyleComponents = new List<string>
        {
            "🦰", // red hair
            "🦱", // curly hair
            "🦳", // white hair
            "🦲", // bald
        };

        private static string ToColonSyntax(string s)
            => Regex.Replace(s.Trim().ToLowerInvariant(), "[^a-z0-9]+", "-");

        private static void ParseEmojiList()
        {
            var match_group = new Regex(@"^# group: (.*)");
            var match_subgroup = new Regex(@"^# subgroup: (.*)");
            var match_sequence = new Regex(@"^([0-9a-fA-F ]+[0-9a-fA-F]).*; *([-a-z]*) *# [^ ]* (E[0-9.]* )?(.*)");
            var match_skin_tone = new Regex($"({string.Join("|", SkinToneComponents)})");
            var match_hair_style = new Regex($"({string.Join("|", HairStyleComponents)})");

            var adult = "(👨|👩)(🏻|🏼|🏽|🏾|🏿)?";
            var child = "(👦|👧|👶)(🏻|🏼|🏽|🏾|🏿)?";
            var match_family = new Regex($"{adult}(\u200d{adult})*(\u200d{child})+");

            var qualified_lut = new Dictionary<string, string>();
            var list = new List<Group>();
            var alltext = new List<string>();

            Group current_group = null;
            SubGroup current_subgroup = null;

            foreach (var line in EmojiDescriptionLines())
            {
                var m = match_group.Match(line);
                if (m.Success)
                {
                    current_group = new Group { Name = m.Groups[1].ToString() };
                    list.Add(current_group);
                    continue;
                }

                m = match_subgroup.Match(line);
                if (m.Success)
                {
                    current_subgroup = new SubGroup { Name = m.Groups[1].ToString(), Group = current_group };
                    current_group.SubGroups.Add(current_subgroup);
                    continue;
                }

                m = match_sequence.Match(line);
                if (m.Success)
                {
                    string sequence = m.Groups[1].ToString();
                    string name = m.Groups[4].ToString();

                    string text = string.Join("", from n in sequence.Split(' ')
                                                  select char.ConvertFromUtf32(Convert.ToInt32(n, 16)));
                    bool has_modifier = false;

                    if (match_family.Match(text).Success)
                    {
                        // If this is a family emoji, no need to add it to our big matching
                        // regex, since the match_family regex is already included.
                    }
                    else
                    {
                        // Construct a regex to replace e.g. "🏻" with "(🏻|🏼|🏽|🏾|🏿)" in a big
                        // regex so that we can match all variations of this Emoji even if they are
                        // not in the standard.
                        bool has_nonfirst_modifier = false;
                        var regex_text = match_skin_tone.Replace(
                            match_hair_style.Replace(text, (x) =>
                            {
                                has_modifier = true;
                                has_nonfirst_modifier |= x.Value != HairStyleComponents[0];
                                return match_hair_style.ToString();
                            }), (x) =>
                            {
                                has_modifier = true;
                                has_nonfirst_modifier |= x.Value != SkinToneComponents[0];
                                return match_skin_tone.ToString();
                            });

                        if (!has_nonfirst_modifier)
                            alltext.Add(has_modifier ? regex_text : text);
                    }

                    // If there is already a differently-qualified version of this character, skip it.
                    // FIXME: this only works well if fully-qualified appears first in the list.
                    var unqualified = text.Replace("\ufe0f", "");
                    if (qualified_lut.ContainsKey(unqualified))
                        continue;

                    qualified_lut[unqualified] = text;

                    var emoji = new Emoji
                    {
                        Name = name,
                        Text = text,
                        SubGroup = current_subgroup,
                        Renderable = Typeface.CanRender(text),
                    };
                    // FIXME: this prevents LookupByText from working with the unqualified version
                    LookupByText[text] = emoji;
                    LookupByName[ToColonSyntax(name)] = emoji;
                    MatchStart.Add(text[0]);

                    // Get the left part of the name and check whether we’re a variation of an existing
                    // emoji. If so, append to that emoji. Otherwise, add to current subgroup.
                    // FIXME: does not work properly because variations can appear before the generic emoji
                    if (name.Contains(":") && LookupByName.TryGetValue(ToColonSyntax(name.Split(':')[0]), out var parent_emoji))
                    {
                        if (parent_emoji.VariationList.Count == 0)
                            parent_emoji.VariationList.Add(parent_emoji);
                        parent_emoji.VariationList.Add(emoji);
                    }
                    else
                        current_subgroup.EmojiList.Add(emoji);
                }
            }

            // Remove the Component group. Not sure we want to have the skin tones in the picker.
            list.RemoveAll(g => g.Name == "Component");
            AllGroups = list;

            // Make U+fe0f optional in the regex so that we can match any combination.
            // FIXME: this is the starting point to implement variation selectors.
            var sortedtext = alltext.OrderByDescending(x => x.Length);
            var match_other = string.Join("|", sortedtext)
                                    .Replace("*", "[*]")
                                    .Replace("\ufe0f", "\ufe0f?");

            // Build a regex that matches any Emoji
            m_match_one_string = match_family.ToString() + "|" + match_other;
            MatchOne = new Regex("(" + m_match_one_string + ")");
        }

        private static IEnumerable<string> EmojiDescriptionLines()
        {
            using (var sr = new GZipResourceStream("emoji-test.txt.gz"))
                return sr.ReadToEnd().Split('\r', '\n');
        }
    }
}

