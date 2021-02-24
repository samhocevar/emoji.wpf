//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2020 Sam Hocevar <sam@hocevar.net>
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
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace Tiny
{
    /// <summary>
    /// Interaction logic for Tiny.xaml
    /// </summary>
    public partial class TinyWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            var rdr = new WpfDrawingRenderer(new WpfDrawingSettings());
            var win = new SharpVectors.Renderers.Utils.WpfSvgWindow(0, 0, rdr);
            var doc = new SharpVectors.Dom.Svg.SvgDocument(win);
            doc.Load(@"C:\Users\s.hocevar\emoji.wpf\sk_mod.svg");
            ParseSvg(doc.DocumentElement);
            doc.Save(@"C:\Users\s.hocevar\emoji.wpf\sk_mod2.svg");

            Application app = new Application();
            app.StartupUri = new Uri("Tiny.xaml", UriKind.Relative);
            app.Run();
        }

        private static double ScaleX, ScaleY;

        private static void ParseSvg(XmlNode node)
        {
            if (node is SvgPathElement path)
            {
                var geometry = Geometry.Parse(path.GetAttribute("d"));
                geometry.Transform = new ScaleTransform(ScaleX, ScaleY);
                path.SetAttribute("d", geometry.GetFlattenedPathGeometry().ToString());
            }
            else if (node is SvgSvgElement svg)
            {
                // Resize viewbox width to 23.068 and slightly stretch vertically to account for flag wave.
                var vbox = svg.ViewBox.BaseVal;
                ScaleX = 23.068 / vbox.Width;
                ScaleY = 23.5284 / vbox.Width;
                svg.SetAttribute("viewBox", $"0 0 {ScaleX * vbox.Width} {ScaleY * vbox.Height}");
            }

            // Recurse
            if (node.HasChildNodes)
                ParseSvg(node.FirstChild);

            if (node.NextSibling != null)
                ParseSvg(node.NextSibling);
        }

        public TinyWindow()
        {
            InitializeComponent();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            => DragMove();
    }
}
