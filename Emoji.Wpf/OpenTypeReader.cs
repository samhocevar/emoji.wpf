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

namespace Emoji.Wpf
{
    public partial class ColorTypeface
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

            public ushort[] ReadUInt16Table(int count)
            {
                ushort[] ret = new ushort[count];
                for (int i = 0; i < count; ++i)
                    ret[i] = ReadUInt16();
                return ret;
            }

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
            foreach (var kv in tables)
            {
                switch (kv.Key)
                {
                    case "GSUB": ReadGSUB(b, kv.Value); break;
                    case "COLR": ReadCOLR(b, kv.Value); break;
                    case "CPAL": ReadCPAL(b, kv.Value); break;
                }
            }
        }
    }
}

