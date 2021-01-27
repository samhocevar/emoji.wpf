//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Typography.TextLayout;

using Controls = System.Windows.Controls;

namespace Emoji.Wpf
{
    public class EmojiCanvas : Controls.Canvas
    {
    }

    public class EmojiInline : InlineUIContainer
    {
        // Need an empty constructor for serialisation (undo/redo)
        public EmojiInline()
            : base(new EmojiCanvas())
        {
            // FIXME: not sure TextBottom is the correct value; but Baseline does not work.
            BaselineAlignment = BaselineAlignment.TextBottom;
        }

        public EmojiInline(TextPointer pos)
            : base(new EmojiCanvas(), pos)
        {
            BaselineAlignment = BaselineAlignment.TextBottom;
        }

        /// <summary>
        /// Redeclare the Child property to prevent it from being serialized.
        /// </summary>
        public new EmojiCanvas Child
        {
            get => base.Child as EmojiCanvas;
            private set => base.Child = value;
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(EmojiInline),
            new PropertyMetadata(""));

        protected override bool ShouldSerializeProperty(DependencyProperty dp)
            => dp.Name == nameof(Text) && base.ShouldSerializeProperty(dp);

        protected bool ShouldSerializeChild() => false;

        private void Rebuild()
        {
            // FIXME: How can Child be null in Sample.exe? Investigate.
            if (Child != null)
            {
                Child?.Children.Clear();
                CreatePathsFromText(Text ?? "", Foreground);
                Child.LayoutTransform = new ScaleTransform(FontSize, FontSize);
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            // FIXME: split this into several code paths
            if (e.Property == FontSizeProperty || e.Property == TextProperty
                 || e.Property == ForegroundProperty)
            {
                Rebuild();
            }
        }

        protected void CreatePathsFromText(string text, Brush brush)
        {
            var font = EmojiData.Typeface;
            var glyphplanlist = font.MakeGlyphPlanList(text);
            var glyphplansequence = new GlyphPlanSequence(glyphplanlist);

#if false
            // Check whether the Emoji font knows about all codepoints;
            // otherwise, set Invalid to true.
            bool invalid = false;
            for (int i = 0; i < glyphplanlist.Count; ++i)
                if (glyphplanlist[i].glyphIndex == 0)
                    invalid = true;
#endif

            // FIXME: I am not sure why the math below works
            var scale = font.GetScale(1.0) * 0.75;
            Child.Width = glyphplansequence.CalculateWidth() * scale;
            Child.Height = 1.0 / 0.75;

            // Render our image
            if (glyphplansequence.Count > 0 && Child.Width > 0 && Child.Height > 0)
            {
                var visual = new DrawingVisual();
                double startx = 0;
                double starty = font.Baseline;
                bool zwj_hack = false;

                for (int i = 0; i < glyphplansequence.Count; ++i)
                {
                    var g = glyphplansequence[i];
                    var size = 1.0;
                    var xpos = startx + g.OffsetX * scale;
                    var ypos = starty + g.OffsetY * scale;

                    if (EmojiData.RenderingFallbackHack)
                    {
                        if (zwj_hack)
                        {
                            zwj_hack = false;
                            xpos += size * 0.25;
                            size *= 0.75;
                        }
                        else if (i + 1 < glyphplansequence.Count && glyphplansequence[i + 1].glyphIndex == font.ZwjGlyph)
                        {
                            zwj_hack = true;
                            ypos -= size * 0.25;
                            size *= 0.75;
                        }
                    }

                    foreach (var p in font.MakePaths(g.glyphIndex, new Point(xpos, ypos), size, brush))
                        Child.Children.Add(p);

                    if (zwj_hack)
                        ++i;
                    else
                        startx += g.AdvanceX * scale;
                }
            }
        }
    }
}

