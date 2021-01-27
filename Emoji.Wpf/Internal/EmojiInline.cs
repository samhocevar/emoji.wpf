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
                var paths = EmojiRenderer.CreatePaths(Text ?? "", FontSize, Foreground, out var width, out var height);
                foreach (var p in paths)
                    Child.Children.Add(p);
                Child.Width = width;
                Child.Height = height;
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
    }
}

