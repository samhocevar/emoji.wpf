//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//
//  This program is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using SharpVectors.Dom.Svg;
using SharpVectors.Renderers.Wpf;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace BuildFlags
{
    public class BuildFlags
    {
        [STAThread]
        public static void Main()
        {
            var rdr = new WpfDrawingRenderer(new WpfDrawingSettings());
            var win = new SharpVectors.Renderers.Utils.WpfSvgWindow(0, 0, rdr);
            var doc = new SharpVectors.Dom.Svg.SvgDocument(win);
            // Must use an absolute path or parsing the SVG will fail (?)
            doc.Load(Directory.GetCurrentDirectory() + @"\..\..\..\Emoji.Wpf\CountryFlags\svg\fr.svg");
            ParseSvg(doc);
            doc.Save(@"..\..\..\fr.svg");
        }

        // Resize viewbox width to 23.068 and slightly stretch vertically to account for flag wave.
        private const double Width = 23.068;
        private const double Ratio = 23.5284 / Width;

        private static double ScaleX, ScaleY;

        private static void ParseSvg(SvgDocument doc)
        {
            var rootgroup = new SvgGElement("", "root", "", doc);
            ParseSvgInternal(doc.DocumentElement, rootgroup, SvgMatrix.Identity);
        }

        private static void ParseSvgInternal(XmlNode node, ISvgGElement rootgroup, ISvgMatrix mat)
        {
            if (node is SvgSvgElement svg)
            {
                var vbox = svg.ViewBox.BaseVal;
                ScaleX = Width / vbox.Width;
                ScaleY = Ratio * ScaleX;
                svg.SetAttribute("viewBox", $"0 0 {ScaleX * vbox.Width} {ScaleY * vbox.Height}");
            }
            else if (node is SvgPathElement path)
            {
                rootgroup.AppendChild(path);
                //var geometry = Geometry.Parse(path.GetAttribute("d"));
                //geometry.Transform = new ScaleTransform(ScaleX, ScaleY);
                //path.SetAttribute("d", geometry.GetFlattenedPathGeometry().ToString());
            }
#if false
            else if (node is SvgGElement g)
            {
                var m2 = g.Transform.BaseVal.Consolidate().Matrix.Multiply(mat);
                if (node.HasChildNodes)
                    ParseSvgInternal(node.FirstChild, rootgroup, m2);
            }
#endif
            else
            {
                // Recurse
                if (node.HasChildNodes)
                    ParseSvgInternal(node.FirstChild, rootgroup, mat);
            }

            if (node.NextSibling != null)
                ParseSvgInternal(node.NextSibling, rootgroup, mat);
        }
    }
}
