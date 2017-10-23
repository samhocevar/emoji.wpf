﻿//
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

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Emoji.Wpf
{
    public class ColorTypeface
    {
        public static readonly string DefaultFont = "Segoe UI Emoji";
        //public static readonly string DefaultFont = "c:\\Program Files\\Mozilla Firefox\\fonts\\EmojiOneMozilla.ttf";

        public ColorTypeface() => Init(DefaultFont);
        public ColorTypeface(string name) => Init(name);

        private void Init(string name)
        {
            // Get a GlyphTypeface either from a typeface or from a file path
            Typeface typeface = new Typeface(name);
            if (!typeface.TryGetGlyphTypeface(out m_gtf))
                m_gtf = new GlyphTypeface(new Uri(name));

            using (var s = m_gtf.GetFontStream())
            {
                var r = new Typography.OpenFont.OpenFontReader();
                m_openfont = r.Read(s, Typography.OpenFont.ReadFlags.Full);
            }

#if FALSE // debug stuff
            var font = m_openfont;

            GlyphIndexList gl = new GlyphIndexList();

            gl.Add(font.LookupIndex(0x1f431)); // U+1F431 CAT FACE
            gl.Add(font.LookupIndex( 0x200d)); //  U+200D ZERO WIDTH JOINER
            gl.Add(font.LookupIndex(0x1f453)); // U+1F453 EYEGLASSES

            //gl.Add(font.LookupIndex(0x1f46a)); // U+1F46A FAMILY
            //gl.Add(font.LookupIndex(0x1f3fe)); // U+1F3FE EMOJI MODIFIER FITZPATRICK TYPE-5

            foreach (var lookup_table in font.GSUBTable.LookupList)
                lookup_table.DoSubstitution(gl, 0, gl.Count);
#endif
        }

        private Dictionary<ushort, int> m_glyphs;

        public IDictionary<ushort, int> GlyphToCharacterMap
        {
            get
            {
                if (m_glyphs == null)
                {
                    m_glyphs = new Dictionary<ushort, int>();
                    if (m_openfont.COLRTable != null)
                        foreach (var kv in m_openfont.COLRTable.LayerIndices)
                            m_glyphs[kv.Key] = 0;
                    for (int codepoint = 0; codepoint < 0xfffff; ++codepoint)
                    {
                        ushort gid = CharacterToGlyphIndex(codepoint);
                        if (gid != 0)
                            m_glyphs[gid] = codepoint;
                    }
                }
                return m_glyphs;
            }
        }

        public bool HasCodepoint(int codepoint) => CharacterToGlyphIndex(codepoint) != 0;
        public ushort CharacterToGlyphIndex(int codepoint) => m_openfont.LookupIndex(codepoint);

        public List<ushort> StringToGlyphIndices(string s)
        {
            // Generate a glyph list
            GlyphIndexList gil = new GlyphIndexList();
            for (int i = 0; i < s.Length; ++i)
            {
                char ch = s[i];
                int codepoint = ch;
                if (ch >= 0xd800 && ch <= 0xdbff && i + 1 < s.Length
                     && s[i + 1] >= 0xdc00 && s[i + 1] <= 0xdfff)
                    codepoint = char.ConvertToUtf32(ch, s[++i]);
                gil.Add(CharacterToGlyphIndex(codepoint));
            }

            // Apply ligatures
            for (int i = 0; i < gil.Count; )
            {
                bool changed = false;
                foreach (var lookup in m_openfont.GSUBTable.LookupList)
                    if (lookup.DoSubstitutionAt(gil, i, gil.Count - i))
                        changed = true;
                if (!changed)
                    ++i;
            }

            return gil;
        }

        public IDictionary<ushort, double> Widths { get => m_gtf.AdvanceWidths; }
        public double Height { get => m_gtf.Height; }
        public double Baseline { get => m_gtf.Baseline; }

        public void RenderGlyph(DrawingContext dc, ushort gid, double size)
        {
            ushort layer_index;
            if (m_openfont.COLRTable != null && m_openfont.CPALTable != null
                 && m_openfont.COLRTable.LayerIndices.TryGetValue(gid, out layer_index))
            {
                int start = layer_index, stop = layer_index + m_openfont.COLRTable.LayerCounts[gid];
                int palette = 0; // FIXME: support multiple palettes?

                for (int i = start; i < stop; ++i)
                {
                    ushort sub_gid = m_openfont.COLRTable.GlyphLayers[i];
                    // We do not need to provide advances since we only render
                    // one glyph.
                    GlyphRun r = new GlyphRun(m_gtf, 0, false, size,
                                              new ushort[] { sub_gid },
                                              new Point(), new double[] { 0 },
                                              null, null, null, // FIXME: check what this is?
                                              null, null, null);
                    int cid = m_openfont.CPALTable.Palettes[palette] + m_openfont.COLRTable.GlyphPalettes[i];
                    byte R, G, B, A;
                    m_openfont.CPALTable.GetColor(cid, out R, out G, out B, out A);
                    Brush b = new SolidColorBrush(Color.FromArgb(A, R, G, B));

                    dc.DrawGlyphRun(b, r);
                }
            }
            else
            {
                GlyphRun r = new GlyphRun(m_gtf, 0, false, size,
                                          new ushort[] { gid },
                                          new Point(), new double[] { 0 },
                                          null, null, null,
                                          null, null, null);
                dc.DrawGlyphRun(Brushes.Black, r);
            }
        }

        protected GlyphTypeface m_gtf;
        protected Typography.OpenFont.Typeface m_openfont;

        internal class GlyphIndexList : List<ushort>, Typography.OpenFont.Tables.IGlyphIndexList
        {
            public void AddGlyph(int index, ushort glyphIndex)
            {
                Insert(index, glyphIndex);
            }

            public void Replace(int index, ushort newGlyphIndex)
            {
                this[index] = newGlyphIndex;
            }

            public void Replace(int index, int removeLen, ushort newGlyhIndex)
            {
                this[index] = newGlyhIndex;
                RemoveRange(index + 1, removeLen - 1);
            }

            public void Replace(int index, ushort[] newGlyhIndices)
            {
                for (int i = 0; i < newGlyhIndices.Length; ++i)
                    this[index + i] = newGlyhIndices[i];
            }
        }
    }
}
