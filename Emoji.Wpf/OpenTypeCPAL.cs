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

using System.Windows.Media;

namespace Emoji.Wpf
{
    public partial class ColorTypeface
    {
        // Read the CPAL table
        // https://www.microsoft.com/typography/otspec/cpal.htm
        private void ReadCPAL(BEBinaryReader b, int offset)
        {
            b.SeekAt(offset);

            int version = b.ReadUInt16();
            int entry_count = b.ReadUInt16(); // XXX: unused?
            int palette_count = b.ReadUInt16();
            m_colors = new Color[b.ReadUInt16()];
            int colors_offset = b.ReadInt32();

            m_palettes = b.ReadUInt16Table(palette_count);
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

