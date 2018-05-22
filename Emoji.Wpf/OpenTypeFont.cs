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
using System.Windows;
using System.Windows.Media;

using Typography.OpenFont;
using Typography.TextLayout;

namespace Emoji.Wpf
{
    public class EmojiTypeface
    {
        public EmojiTypeface() => Init(null);
        public EmojiTypeface(string name) => Init(name);

        private void Init(string name)
        {
            m_gtf = GetGlyphTypeface(first_candidate: name);
            if (m_gtf == null)
                return;

            // Read the actual font data using Typography.OpenFont
            using (var s = m_gtf.GetFontStream())
            {
                var r = new Typography.OpenFont.OpenFontReader();
                m_openfont = r.Read(s, Typography.OpenFont.ReadFlags.Full);
            }

            // Create a layout for glyphs
            m_layout = new GlyphLayout();
            m_layout.ScriptLang = ScriptLangs.Default;
            m_layout.Typeface = m_openfont;
            m_layout.PositionTechnique = PositionTechnique.OpenFont;

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

        private GlyphTypeface GetGlyphTypeface(string first_candidate)
        {
            IList<string> all_candidates = new List<string>();

            if (first_candidate != null)
                all_candidates.Add(first_candidate);

            // Some good Emoji font candidates
            all_candidates.Add("Segoe UI Emoji");
            all_candidates.Add(@"c:\Windows\Fonts\seguiemj.ttf");

            // Maybe try the Firefox EmojiOne font?
            var firefox_key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\firefox.exe";
            var firefox_path = Microsoft.Win32.Registry.GetValue(firefox_key, "Path", null);
            if (firefox_path is string)
                all_candidates.Add((firefox_path as string) + @"\fonts\EmojiOneMozilla.ttf");

            // Last resort fallbacks
            all_candidates.Add("Segoe UI Symbol"); // for older versions of Windows
            all_candidates.Add("Arial"); // available since Windows 3.1!

            foreach (var name in all_candidates)
            {
                var typeface = new System.Windows.Media.Typeface(name);
                if (typeface.TryGetGlyphTypeface(out var gtf))
                    return gtf;

                try
                {
                    return new GlyphTypeface(new Uri(name));
                }
                catch {}
            }

            return null;
        }

        // FIXME: this should be phased out when RichTextBox is upgraded
        public bool HasCodepoint(int codepoint) => CharacterToGlyphIndex(codepoint) != 0;
        public ushort CharacterToGlyphIndex(int codepoint) => m_openfont.LookupIndex(codepoint);

        /// <summary>
        /// Return whether the font can render the given string entirely
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CanRender(string s)
        {
            m_layout.Layout(s.ToCharArray(), 0, s.Length);
            for (int i = 0; i < m_layout.ResultUnscaledGlyphPositions.Count; ++i)
                if (m_layout.ResultUnscaledGlyphPositions.GetGlyph(i, out var dummy) == 0)
                    return false;
            return true;
        }

        public GlyphPlanList StringToGlyphPlanList(string s, double font_size)
        {
            GlyphPlanList l = new GlyphPlanList();
            m_layout.Layout(s.ToCharArray(), 0, s.Length);
            var scale = m_openfont.CalculateScaleToPixelFromPointSize((float)font_size);
            GlyphLayoutExtensions.GenerateGlyphPlan(m_layout.ResultUnscaledGlyphPositions, scale,
                                                    snapToGrid: true, outputGlyphPlanList: l);
            return l;
        }

        public IDictionary<ushort, double> AdvanceWidths { get => m_gtf.AdvanceWidths; }
        public IDictionary<ushort, double> AdvanceHeights { get => m_gtf.AdvanceHeights; }
        public double Height { get => m_gtf.Height; }
        public double Baseline { get => m_gtf.Baseline; }

        public void RenderGlyph(DrawingContext dc, ushort gid, Point origin, double size, Brush nonEmojiBrush)
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
                                              origin, new double[] { 0 },
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
                                          origin, new double[] { 0 },
                                          null, null, null,
                                          null, null, null);
                dc.DrawGlyphRun(nonEmojiBrush, r);
            }
        }

        protected GlyphTypeface m_gtf;
        protected Typography.OpenFont.Typeface m_openfont;
        protected GlyphLayout m_layout;

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

