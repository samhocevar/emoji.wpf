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

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace Emoji.Wpf
{
    public class ColorTypeface : Typeface
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

        /// <summary>
        /// Big-endian binary reader for TrueType/OTF fonts.
        /// </summary>
        private class BEBinaryReader : BinaryReader
        {
            public BEBinaryReader(Stream s) : base(s) { }

            public override short ReadInt16() => BitConverter.ToInt16(ReadReverse(2), 0);
            public override ushort ReadUInt16() => BitConverter.ToUInt16(ReadReverse(2), 0);
            public override int ReadInt32() => BitConverter.ToInt32(ReadReverse(4), 0);
            public override uint ReadUInt32() => BitConverter.ToUInt32(ReadReverse(4), 0);
            public override long ReadInt64() => BitConverter.ToInt64(ReadReverse(8), 0);
            public override ulong ReadUInt64() => BitConverter.ToUInt64(ReadReverse(8), 0);

            public void SeekAt(int offset) => BaseStream.Seek(offset, SeekOrigin.Begin);

            private byte[] ReadReverse(int count)
            {
                var b = ReadBytes(count); Array.Reverse(b); return b;
            }
        }

        private class TableLocation
        {
            public TableLocation(int offset, int length)
            {
                Offset = offset;
                Length = length;
            }

            public int Offset { get; }
            public int Length { get; }
        }

        private enum Tag : uint
        {
            COLR = 0x434f4c52,
            CPAL = 0x4350414c,
            GDEF = 0x47444546,
            GSUB = 0x47535542,
        }

        private void ReadFontStream(Stream s)
        {
            // Read font header
            var b = new BEBinaryReader(s);
            uint font_header = b.ReadUInt32();
            int table_count = b.ReadUInt16();
            b.SeekAt(12);

            // Read available table information
            Dictionary<Tag, int> tables = new Dictionary<Tag, int>();
            for (int i = 0; i < table_count; ++i)
            {
                Tag tag = (Tag)b.ReadUInt32();
                uint checksum = b.ReadUInt32();
                int offset = b.ReadInt32();
                int length = b.ReadInt32(); // Ignored, lol
                tables[tag] = offset;
            }

            // Parse tables that are relevant to us
            int table_offset;
            if (tables.TryGetValue(Tag.GSUB, out table_offset))
                ReadGSUB(b, table_offset);
            if (tables.TryGetValue(Tag.COLR, out table_offset))
                ReadCOLR(b, table_offset);
            if (tables.TryGetValue(Tag.CPAL, out table_offset))
                ReadCPAL(b, table_offset);
        }

        // Read the GSUB table
        // https://www.microsoft.com/typography/otspec/gsub.htm
        // https://www.microsoft.com/typography/otspec/chapter2.htm
        private void ReadGSUB(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);
            ushort major_version = b.ReadUInt16();
            ushort minor_version = b.ReadUInt16();
            int script_list_offset = b.ReadInt16();
            int feature_list_offset = b.ReadInt16();
            int lookup_list_offset = b.ReadInt16();
            int variations_list_offset = minor_version == 1 ? b.ReadInt32() : 0;

            // Read script list table
            Dictionary<Tag, int> scripts = new Dictionary<Tag, int>();
            b.SeekAt(offset + script_list_offset);
            int script_count = b.ReadInt16();
            for (int i = 0; i < script_count; ++i)
            {
                Tag tag = (Tag)b.ReadUInt32();
                scripts[tag] = b.ReadUInt16();
            }

            // Read feature list table
            Dictionary<Tag, int> features = new Dictionary<Tag, int>();
            b.SeekAt(offset + feature_list_offset);
            int feature_count = b.ReadInt16();
            for (int i = 0; i < feature_count; ++i)
            {
                Tag tag = (Tag)b.ReadUInt32();
                features[tag] = b.ReadUInt16();
            }

            // Read lookup list table
            List<int> lookups = new List<int>();
            b.SeekAt(offset + lookup_list_offset);
            int lookup_count = b.ReadInt16();
            for (int i = 0; i < lookup_count; ++i)
                lookups.Add(b.ReadInt16());
        }

        // Read the COLR table
        // https://www.microsoft.com/typography/otspec/colr.htm
        private void ReadCOLR(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);
            ushort version = b.ReadUInt16();
            int glyph_count = b.ReadUInt16();
            int glyphs_offset = b.ReadInt32();
            int layers_offset = b.ReadInt32();
            int layer_count = b.ReadUInt16();

            b.SeekAt(offset + glyphs_offset);
            for (int i = 0; i < glyph_count; ++i)
            {
                ushort gid = b.ReadUInt16();
                m_layer_indices[gid] = b.ReadUInt16();
                m_layer_counts[gid] = b.ReadUInt16();
            }

            b.SeekAt(offset + layers_offset);
            m_glyph_layers = new ushort[layer_count];
            m_glyph_palettes = new ushort[layer_count];
            for (int i = 0; i < layer_count; ++i)
            {
                m_glyph_layers[i] = b.ReadUInt16();
                m_glyph_palettes[i] = b.ReadUInt16();
            }
        }

        // Read the CPAL table
        // https://www.microsoft.com/typography/otspec/cpal.htm
        private void ReadCPAL(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);
            ushort palette_version = b.ReadUInt16();
            int entry_count = b.ReadUInt16();
            int palette_count = b.ReadUInt16();
            int color_count = b.ReadUInt16();
            int colors_offset = b.ReadInt32();

            m_palettes = new ushort[palette_count];
            for (int i = 0; i < palette_count; ++i)
            {
                m_palettes[i] = b.ReadUInt16();
            }

            b.SeekAt(offset + colors_offset);
            m_colors = new Color[color_count];
            for (int i = 0; i < color_count; ++i)
            {
                byte[] tmp = b.ReadBytes(4);
                m_colors[i] = Color.FromArgb(tmp[3], tmp[2], tmp[1], tmp[0]);
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

