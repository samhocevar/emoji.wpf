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

namespace Emoji.Wpf
{
    public partial class ColorTypeface
    {
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
    }
}

