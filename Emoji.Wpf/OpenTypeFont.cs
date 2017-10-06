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
        public ColorTypeface(string name)
          : base(name)
        {
            if (TryGetGlyphTypeface(out m_gtf))
            {
                using (var s = m_gtf.GetFontStream())
                {
                    ReadFontStream(s);
                }
            }
        }

        public bool HasCodepoint(int codepoint)
        {
            // Just check that the character is mapped to a glyph
            return m_gtf.CharacterToGlyphMap.ContainsKey(codepoint);
            // Check that the character is mapped to a glyph, and that the glyph
            // has colour information. Otherwise, we are not interested.
            //ushort glyph;
            //return m_gtf.CharacterToGlyphMap.TryGetValue(codepoint, out glyph)
            //        && m_layer_indices.ContainsKey(glyph);
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
                    foreach (var kv in m_gtf.CharacterToGlyphMap)
                        m_glyphs[kv.Value] = kv.Key;
                }
                return m_glyphs;
            }
        }

        public IDictionary<int, ushort> CharacterToGlyphMap { get => m_gtf.CharacterToGlyphMap; }
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

        private Dictionary<ushort, ushort> m_layer_indices = new Dictionary<ushort, ushort>();
        private Dictionary<ushort, ushort> m_layer_counts = new Dictionary<ushort, ushort>();
        private ushort[] m_glyph_layers = new ushort[0];
        private ushort[] m_glyph_palettes = new ushort[0];
        private ushort[] m_palettes = new ushort[0];
        private Color[] m_colors = new Color[0];
    }
}

