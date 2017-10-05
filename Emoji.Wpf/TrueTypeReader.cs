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
using System.Text;
using System.Windows.Media;

namespace Emoji.Wpf
{
    public partial class ColorTypeface : Typeface
    {
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

            public string ReadTag() => Encoding.ASCII.GetString(ReadBytes(4));

            public void SeekAt(int offset) => BaseStream.Seek(offset, SeekOrigin.Begin);

            private byte[] ReadReverse(int count)
            {
                var b = ReadBytes(count); Array.Reverse(b); return b;
            }
        }

        private void ReadFontStream(Stream s)
        {
            // Read font header
            var b = new BEBinaryReader(s);
            uint font_header = b.ReadUInt32();
            int table_count = b.ReadUInt16();
            b.SeekAt(12);

            // Read available table information
            Dictionary<string, int> tables = new Dictionary<string, int>();
            for (int i = 0; i < table_count; ++i)
            {
                string tag = b.ReadTag();
                uint checksum = b.ReadUInt32();
                int offset = b.ReadInt32();
                int length = b.ReadInt32(); // Ignored, lol
                tables[tag] = offset;
            }

            // Parse tables that are relevant to us
            int table_offset;
            if (tables.TryGetValue("GSUB", out table_offset))
                ReadGSUB(b, table_offset);
            if (tables.TryGetValue("COLR", out table_offset))
                ReadCOLR(b, table_offset);
            if (tables.TryGetValue("CPAL", out table_offset))
                ReadCPAL(b, table_offset);
        }

        // Read the GSUB table
        // https://www.microsoft.com/typography/otspec/gsub.htm
        // https://www.microsoft.com/typography/otspec/chapter2.htm
        private void ReadGSUB(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);

            int major_version = b.ReadUInt16();
            int minor_version = b.ReadUInt16();
            int script_list_offset = b.ReadInt16();
            int feature_list_offset = b.ReadInt16();
            int lookup_list_offset = b.ReadInt16();
            int variations_list_offset = minor_version == 1 ? b.ReadInt32() : 0;

            // Read script list table
            Dictionary<string, int> scripts = new Dictionary<string, int>();
            b.SeekAt(offset + script_list_offset);
            int script_count = b.ReadInt16();
            for (int i = 0; i < script_count; ++i)
            {
                string tag = b.ReadTag();
                scripts[tag] = b.ReadUInt16();
            }

            // Read feature list table
            Dictionary<string, int> features = new Dictionary<string, int>();
            b.SeekAt(offset + feature_list_offset);
            int feature_count = b.ReadInt16();
            for (int i = 0; i < feature_count; ++i)
            {
                string tag = b.ReadTag();
                features[tag] = b.ReadUInt16();
            }

            // Read lookup list table
            b.SeekAt(offset + lookup_list_offset);
            int[] lookups = new int[b.ReadInt16()];
            for (int i = 0; i < lookups.Length; ++i)
                lookups[i] = b.ReadInt16();

            foreach (int lookup_offset in lookups)
                ReadGSUBLookup(b, offset + lookup_list_offset + lookup_offset);
        }

        void ReadGSUBLookup(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);

            int type = b.ReadUInt16();
            int flag = b.ReadUInt16();
            int[] subtable_offsets = new int[b.ReadUInt16()];
            for (int i = 0; i < subtable_offsets.Length; ++i)
                subtable_offsets[i] = offset + b.ReadUInt16();

            // Extension substitution tables need an extra indirection
            if (type == 0x0007)
            {
                for (int i = 0; i < subtable_offsets.Length; ++i)
                {
                    b.SeekAt(subtable_offsets[i]);
                    b.ReadUInt16(); // must be 1
                    type = b.ReadUInt16(); // must all be the same
                    subtable_offsets[i] += b.ReadInt32();
                }
            }

            foreach (int subtable_offset in subtable_offsets)
            {
                switch (type)
                {
                case 0x0001: ReadGSUBLookupType1(b, subtable_offset); break;
                case 0x0004: ReadGSUBLookupType4(b, subtable_offset); break;
                case 0x0006: ReadGSUBLookupType6(b, subtable_offset); break;
                default: break;
                }
            }
        }

        // LookupType 1: Single Substitution Subtable
        void ReadGSUBLookupType1(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);

            int format = b.ReadUInt16();
            int coverage_offset = b.ReadUInt16();
            switch (format)
            {
                case 1:
                    int delta = b.ReadUInt16();
                    break;
                case 2:
                    int[] substitutes = new int[b.ReadUInt16()];
                    for (int i = 0; i < substitutes.Length; ++i)
                        substitutes[i] = b.ReadUInt16();
                    break;
            }
        }

        void ReadGSUBLookupType4(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);
        }

        void ReadGSUBLookupType6(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);
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
            int layers_count = b.ReadUInt16();
            m_glyph_layers = new ushort[layers_count];
            m_glyph_palettes = new ushort[layers_count];

            b.SeekAt(offset + glyphs_offset);
            for (int i = 0; i < glyph_count; ++i)
            {
                ushort gid = b.ReadUInt16();
                m_layer_indices[gid] = b.ReadUInt16();
                m_layer_counts[gid] = b.ReadUInt16();
            }

            b.SeekAt(offset + layers_offset);
            for (int i = 0; i < m_glyph_layers.Length; ++i)
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

            int version = b.ReadUInt16();
            int entry_count = b.ReadUInt16(); // XXX: unused?
            m_palettes = new ushort[b.ReadUInt16()];
            m_colors = new Color[b.ReadUInt16()];
            int colors_offset = b.ReadInt32();

            for (int i = 0; i < m_palettes.Length; ++i)
                m_palettes[i] = b.ReadUInt16();

            b.SeekAt(offset + colors_offset);
            for (int i = 0; i < m_colors.Length; ++i)
            {
                byte[] tmp = b.ReadBytes(4);
                m_colors[i] = Color.FromArgb(tmp[3], tmp[2], tmp[1], tmp[0]);
            }
        }
    }
}

