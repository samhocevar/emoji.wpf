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
using System.Windows;
using System.Windows.Media;

namespace Emoji.Wpf
{
    public partial class ColorTypeface : Typeface
    {
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

        public ColorTypeface(string name)
          : base(name)
        {
            if (TryGetGlyphTypeface(out m_gtf))
            {
                // New strategy: use Typography.OpenFont
                using (var s = m_gtf.GetFontStream())
                {
                    var r = new Typography.OpenFont.OpenFontReader();
                    m_openfont = r.Read(s, Typography.OpenFont.ReadFlags.Full);
                }

                using (var s = m_gtf.GetFontStream())
                {
                    ReadFontStream(s);
                }
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
                    foreach (var kv in m_layer_indices)
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

        public IDictionary<ushort, double> Widths { get => m_gtf.AdvanceWidths; }
        public double Height { get => m_gtf.Height; }
        public double Baseline { get => m_gtf.Baseline; }

        public void RenderGlyph(DrawingContext dc, ushort gid, double size)
        {
            if (m_layer_indices.ContainsKey(gid))
            {
                int start = m_layer_indices[gid], stop = start + m_layer_counts[gid];
                int palette = 0; // FIXME: support multiple palettes?

                for (int i = start; i < stop; ++i)
                {
                    // We do not need to provide advances since we only render
                    // one glyph.
                    GlyphRun r = new GlyphRun(m_gtf, 0, false, size,
                                              new ushort[] { m_glyph_layers[i] },
                                              new Point(), new double[] { 0 },
                                              null, null, null, // FIXME: check what this is?
                                              null, null, null);
                    Brush b = new SolidColorBrush(m_colors[m_palettes[palette] + m_glyph_palettes[i]]);

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

        private Dictionary<ushort, ushort> m_layer_indices = new Dictionary<ushort, ushort>();
        private Dictionary<ushort, ushort> m_layer_counts = new Dictionary<ushort, ushort>();
        private ushort[] m_glyph_layers = new ushort[0];
        private ushort[] m_glyph_palettes = new ushort[0];
        private ushort[] m_palettes = new ushort[0];
        private Color[] m_colors = new Color[0];
    }
}

