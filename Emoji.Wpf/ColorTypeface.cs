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
                Widths = new WidthList(m_gtf);
                using (var s = m_gtf.GetFontStream())
                {
                    ReadFontStream(s);
                }
            }
        }

        public bool HasCodepoint(int codepoint)
        {
            // Check that the character is mapped to a glyph, and that the glyph
            // has colour information. Otherwise, we are not interested.
            ushort glyph;
            return m_gtf.CharacterToGlyphMap.TryGetValue(codepoint, out glyph)
                    && m_layer_indices.ContainsKey(glyph);
        }

        private Dictionary<int, ushort> m_characters;
        private Dictionary<ushort, int> m_glyphs;

        public IDictionary<int, ushort> CharacterToGlyphMap
        {
            get
            {
                if (m_characters == null)
                {
                    m_characters = new Dictionary<int, ushort>();
                    foreach (var kv in m_gtf.CharacterToGlyphMap)
                        if (m_layer_indices.ContainsKey(kv.Value))
                            m_characters[kv.Key] = kv.Value;
                }
                return m_characters;
            }
        }

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

        public struct WidthList
        {
            public WidthList(GlyphTypeface gtf) { m_gtf = gtf; }
            public double this[ushort glyph] => m_gtf.AdvanceWidths[glyph];
            private GlyphTypeface m_gtf;
        }

        public readonly WidthList Widths;
        public double Height { get => m_gtf.Height; }
        public double Baseline { get => m_gtf.Baseline; }

        public void RenderGlyph(DrawingContext dc, ushort gid, double size)
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

        /// <summary>
        /// Big-endian binary reader for TrueType/OTF fonts.
        /// </summary>
        private class BEBinaryReader : BinaryReader
        {
            public BEBinaryReader(Stream s) : base(s) {}

            public override short  ReadInt16()  => BitConverter.ToInt16(ReadReverse(2), 0);
            public override ushort ReadUInt16() => BitConverter.ToUInt16(ReadReverse(2), 0);
            public override int    ReadInt32()  => BitConverter.ToInt32(ReadReverse(4), 0);
            public override uint   ReadUInt32() => BitConverter.ToUInt32(ReadReverse(4), 0);
            public override long   ReadInt64()  => BitConverter.ToInt64(ReadReverse(8), 0);
            public override ulong  ReadUInt64() => BitConverter.ToUInt64(ReadReverse(8), 0);

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

        private enum TableHeader : uint
        {
            COLR = 0x434f4c52,
            CPAL = 0x4350414c,
            GDEF = 0x46454447,
        }

        private void ReadFontStream(Stream s)
        {
            Dictionary<TableHeader, TableLocation> tables = new Dictionary<TableHeader, TableLocation>();

            // Read font header
            var b = new BEBinaryReader(s);
            uint font_header = b.ReadUInt32();
            int table_count = b.ReadUInt16();
            b.BaseStream.Seek(6, SeekOrigin.Current);

            // Read available table information
            for (int i = 0; i < table_count; ++i)
            {
                TableHeader header = (TableHeader)b.ReadUInt32();
                uint checksum = b.ReadUInt32();
                int offset = b.ReadInt32();
                int length = b.ReadInt32();

                tables[header] = new TableLocation(offset, length);
            }

            if (tables.ContainsKey(TableHeader.GDEF))
            {
                // Read the GDEF table
                // https://www.microsoft.com/typography/otspec/gdef.htm
                b.BaseStream.Seek(tables[TableHeader.GDEF].Offset, SeekOrigin.Begin);
                ushort version = b.ReadUInt16();
            }

            if (tables.ContainsKey(TableHeader.COLR) && tables.ContainsKey(TableHeader.CPAL))
            {
                // Read the COLR table
                // https://www.microsoft.com/typography/otspec/colr.htm
                b.BaseStream.Seek(tables[TableHeader.COLR].Offset, SeekOrigin.Begin);
                ushort version = b.ReadUInt16();
                int glyph_count = b.ReadUInt16();
                int glyphs_offset = b.ReadInt32();
                int layers_offset = b.ReadInt32();
                int layer_count = b.ReadUInt16();

                b.BaseStream.Seek(tables[TableHeader.COLR].Offset + glyphs_offset, SeekOrigin.Begin);
                for (int i = 0; i < glyph_count; ++i)
                {
                    ushort gid = b.ReadUInt16();
                    m_layer_indices[gid] = b.ReadUInt16();
                    m_layer_counts[gid] = b.ReadUInt16();
                }

                b.BaseStream.Seek(tables[TableHeader.COLR].Offset + layers_offset, SeekOrigin.Begin);
                m_glyph_layers = new ushort[layer_count];
                m_glyph_palettes = new ushort[layer_count];
                for (int i = 0; i < layer_count; ++i)
                {
                    m_glyph_layers[i] = b.ReadUInt16();
                    m_glyph_palettes[i] = b.ReadUInt16();
                }

                // Read the CPAL table
                // https://www.microsoft.com/typography/otspec/cpal.htm
                b.BaseStream.Seek(tables[TableHeader.CPAL].Offset, SeekOrigin.Begin);
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

                b.BaseStream.Seek(tables[TableHeader.CPAL].Offset + colors_offset, SeekOrigin.Begin);
                m_colors = new Color[color_count];
                for (int i = 0; i < color_count; ++i)
                {
                    byte[] tmp = b.ReadBytes(4);
                    m_colors[i] = Color.FromArgb(tmp[3], tmp[2], tmp[1], tmp[0]);
                }
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

