//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2022 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Typography.OpenFont;
using Typography.TextLayout;

namespace Emoji.Wpf
{
    /// <summary>
    /// The EmojiTypeface class exposes layout and rendering primitives from a
    /// ColorTypeface. In the future this object may use several ColorTypeFace
    /// for better coverage.
    /// </summary>
    public class EmojiTypeface
    {
        public EmojiTypeface(string font_name = null)
            => m_fonts.Add(new ColorTypeface(font_name));

        public double Height
            => (double)m_fonts.FirstOrDefault()?.Height;

        public double Baseline
            => (double)m_fonts.FirstOrDefault()?.Baseline;

        public bool CanRender(string s)
            => m_fonts[0].CanRender(s);

        public double GetScale(double point_size)
            => m_fonts[0].GetScale(point_size);

        public ushort ZwjGlyph
            => m_fonts[0].ZwjGlyph;

        public bool HasFlagGlyphs
            => m_fonts[0].HasFlagGlyphs;

        public bool HasWin11Emoji
            => m_fonts[0].HasWin11Emoji;

        public IEnumerable<ushort> MakeGlyphIndexList(string s)
            => MakeGlyphPlanList(s).Select(x => x.glyphIndex);

        internal IList<UnscaledGlyphPlan> MakeGlyphPlanList(string s)
        {
            if (!m_cache.TryGetValue(s, out var ret))
                m_cache[s] = ret = m_fonts[0].StringToGlyphPlans(s).ToList();
            return ret;
        }

        internal IEnumerable<(GlyphRun, Brush)> DrawGlyph(ushort gid)
            => m_fonts[0].DrawGlyph(gid);

        /// <summary>
        /// A cache of GlyphPlanList objects, indexed by source strings. Should
        /// remain pretty lightweight because they are small objects.
        /// FIXME: measure how many cache hits we actually benefit from
        /// </summary>
        private readonly IDictionary<string, IList<UnscaledGlyphPlan>> m_cache
            = new Dictionary<string, IList<UnscaledGlyphPlan>>();

        private readonly IList<ColorTypeface> m_fonts = new List<ColorTypeface>();
    }

    internal class ColorTypeface
    {
        public ColorTypeface(string name)
        {
            m_gtf = GetGlyphTypeface(first_candidate: name);
            if (m_gtf == null)
                return;

            // Read the actual font data using Typography.OpenFont
            using (var s = m_gtf.GetFontStream())
            {
                var r = new OpenFontReader();
                m_openfont = r.Read(s, 0, ReadFlags.Full);
            }

            // Create a reusable layout for glyphs
            m_layout = new GlyphLayout
            {
                Typeface = m_openfont,
                EnableBuiltinMathItalicCorrection = false, // not needed
                EnableComposition = true,
                EnableGpos = true,
                EnableGsub = true,
                EnableLigature = true,
                PositionTechnique = PositionTechnique.OpenFont,
                ScriptLang = new ScriptLang("DFLT"),
            };

            // Cache the glyph index for the zero-width joiner
            ZwjGlyph = StringToGlyphPlans("\u200d", use_gpos: false).FirstOrDefault().glyphIndex;

            // Check whether the font has flag glyphs (Segoe UI Emoji doesn’t)
            HasFlagGlyphs = StringToGlyphPlans("\U0001f1fa\U0001f1f8", use_gpos: false)
                                .Count(x => x.glyphIndex != 0) == 1;

            // Check whether the font is the Win11 Emoji font; it seems to have started with version 1.33
            if (m_openfont.Name.ToLower() == "segoe ui emoji")
            {
                var version = m_openfont.VersionString.Split(new char[] {' ', '.'});
                HasWin11Emoji = version.Length >= 3 && version[0].ToLower() == "version"
                    && int.TryParse(version[1], out var major) && (major >= 2 || (major == 1
                        && int.TryParse(version[2], out var minor) && minor >= 33));
            }
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
            if (firefox_path is string s)
                all_candidates.Add($@"{s}\fonts\EmojiOneMozilla.ttf");

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

        /// <summary>
        /// Return whether the font can render the given string entirely
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CanRender(string s)
            => StringToGlyphPlans(s, use_gpos: false)
                   .All(g => g.glyphIndex != 0 && g.glyphIndex != ZwjGlyph);

        internal IEnumerable<UnscaledGlyphPlan> StringToGlyphPlans(string s, bool use_gpos = true)
        {
            lock (m_layout)
            {
                m_layout.EnableGpos = use_gpos;
                m_layout.Layout(s.ToCharArray(), 0, s.Length);
                return m_layout.GetUnscaledGlyphPlanIter();
            }
        }

        public double GetScale(double point_size)
            => m_openfont.CalculateScaleToPixelFromPointSize((float)point_size);

        public double Height => (m_openfont.ClipedAscender + m_openfont.ClipedDescender) / (double)m_openfont.UnitsPerEm;

        public double Baseline => m_openfont.ClipedAscender / (double)m_openfont.UnitsPerEm;
        public ushort ZwjGlyph { get; private set; }
        public bool HasFlagGlyphs { get; private set; }
        public bool HasWin11Emoji { get; private set; }

        public IEnumerable<(GlyphRun, Brush)> DrawGlyph(ushort gid)
        {
            if (m_openfont.COLRTable != null && m_openfont.CPALTable != null
                 && m_openfont.COLRTable.LayerIndices.TryGetValue(gid, out var layer_index))
            {
                int start = layer_index, stop = layer_index + m_openfont.COLRTable.LayerCounts[gid];
                int palette = 0; // FIXME: support multiple palettes?

                for (int i = start; i < stop; ++i)
                {
                    ushort sub_gid = m_openfont.COLRTable.GlyphLayers[i];
                    int cid = m_openfont.CPALTable.Palettes[palette] + m_openfont.COLRTable.GlyphPalettes[i];
                    m_openfont.CPALTable.GetColor(cid, out var r, out var g, out var b, out var a);

                    yield return (MakeGlyphRun(sub_gid), new SolidColorBrush(Color.FromArgb(a, r, g, b)));
                }
            }
            else
            {
                yield return (MakeGlyphRun(gid), Brushes.Black);
            }
        }

        private GlyphRun MakeGlyphRun(ushort gid)
            // We do not need to provide advances since we only render one glyph.
            => new GlyphRun(m_gtf, 0, false, 1.0, new[] { gid }, new Point(), new[] { 0.0 },
                            null, null, null, /* FIXME: check what this is? */ null, null, null);

        protected GlyphTypeface m_gtf;
        protected Typography.OpenFont.Typeface m_openfont;
        protected GlyphLayout m_layout;
    }
}

