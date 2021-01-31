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
        public static Regex MatchMultiple { get; private set; }

        public static bool RenderingFallbackHack { get; } = true;

        // FIXME: should we lazy load this? If the user calls Load() later, then
        // this first Load() call will have been for nothing.
        static EmojiData() => Load();

        public static void Load()
            => Load(null);

        public static void Load(string font_name)
        {
            Typeface = new EmojiTypeface(font_name);
            ParseEmojiList();
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

                    // Only add fully-qualified characters to the groups, or we will
                    // end with a lot of dupes.
                    if (line.Contains("unqualified") || line.Contains("minimally-qualified"))
                    {
                        // Skip this if there is already a fully qualified version
                        if (LookupByText.ContainsKey(text + "\ufe0f"))
                            continue;
                        if (LookupByText.ContainsKey(text.Replace("\u20e3", "\ufe0f\u20e3")))
                            continue;
                    }

                    var emoji = new Emoji
                    {
                        Name = name,
                        Text = text,
                        SubGroup = current_subgroup,
                        Renderable = Typeface.CanRender(text),
                    };
                    LookupByText[text] = emoji;
                    LookupByName[name] = emoji;

                    // Get the left part of the name and check whether we’re a variation of an existing
                    // emoji. If so, append to that emoji. Otherwise, add to current subgroup.
                    // FIXME: does not work properly because variations can appear before the generic emoji
                    if (name.Contains(":") && LookupByName.TryGetValue(name.Split(':')[0], out var parent_emoji))
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

            // Build a regex that matches any Emoji
            var sortedtext = alltext.OrderByDescending(x => x.Length);
            var regextext = "(" + match_family.ToString() + "|" + string.Join("|", sortedtext).Replace("*", "[*]") + ")";
            MatchOne = new Regex(regextext);
            MatchMultiple = new Regex(regextext + "+");
        }

        private static IEnumerable<string> EmojiDescriptionLines()
        {
            using (var sr = new GZipResourceStream("emoji-test.txt.gz"))
            {
                foreach (var line in sr.ReadToEnd().Split('\r', '\n'))
                {
                    yield return line;

                    // Append these extra Microsoft emoji after 😾 E2.0 pouting cat
                    if (line.StartsWith("1F63E  "))
                    {
                        yield return "1F431 200D 1F3CD ; fully-qualified # 🐱\u200d🏍 stunt cat";
                        yield return "1F431 200D 1F453 ; fully-qualified # 🐱\u200d👓 hipster cat";
                        yield return "1F431 200D 1F680 ; fully-qualified # 🐱\u200d🚀 astro cat";
                        yield return "1F431 200D 1F464 ; fully-qualified # 🐱\u200d👤 ninja cat";
                        yield return "1F431 200D 1F409 ; fully-qualified # 🐱\u200d🐉 dino cat";
                        yield return "1F431 200D 1F4BB ; fully-qualified # 🐱\u200d💻 hacker cat";
                    }
                }
            }
        }
    }
}

