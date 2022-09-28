//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017—2021 Sam Hocevar <sam@hocevar.net>
//                   2022 Charles Spitzer <charles.spitzer@dont-nod.com>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

using Emoji.Wpf;
using Emoji.Wpf.BBCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace BBCodeEditor
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        private Func<FlowDocument, string> m_display_method = null;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("BBCodeEditor.xaml", UriKind.Relative);
            app.Run();
        }

        public EditorWindow()
        {
            InitializeComponent();
            Loaded += (o, e) => Update();
            EmojiTextBox.BBCodeMarkups = new List<BBCodeMarkup>
            {
                new BBCodeMarkup
                {
                    Name = "Test",
                    Markup = "test",
                    Foreground = Colors.Blue,
                    FontWeight = FontWeights.SemiBold,
                    Shortcut = "Ctrl+T"
                },
            };
        }

        private void Update()
        {
            if (IsLoaded)
            {
                CodeTextBox.Text = m_display_method?.Invoke(EmojiTextBox.Document);
                BBCodeTextBox.Text = EmojiTextBox.BBCodeText;
                PlainTextBox.Text = EmojiTextBox.BBCodeText.GetBBCodePlainText();
            }
        }

        private void EmojiTextBox_TextChanged(object sender, TextChangedEventArgs e) => Update();
        private void EmojiTextBox_SelectionChanged(object sender, RoutedEventArgs e) => Update();

        private string GetCaretContext(FlowDocument document)
        {
            var result = "";
            var startb = EmojiTextBox.CaretPosition.GetNextContextPosition(LogicalDirection.Backward);
            var startf = EmojiTextBox.CaretPosition.GetNextContextPosition(LogicalDirection.Forward);

            if (startb != null && startf != null)
            {
                var elementb1 = startb.GetAdjacentElement(LogicalDirection.Backward)?.GetType().Name;
                var elementb2 = startb.GetAdjacentElement(LogicalDirection.Forward)?.GetType().Name;
                var elementf1 = startf.GetAdjacentElement(LogicalDirection.Backward)?.GetType().Name;
                var elementf2 = startf.GetAdjacentElement(LogicalDirection.Forward)?.GetType().Name;
                result += $"\n";
                result += $"Caret Direction : {EmojiTextBox.CaretPosition.LogicalDirection}\n";
                result += $"\n";
                result += $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
                result += $"\n";
                result += $"Caret Context :\n";
                result += $"     ←  : {EmojiTextBox.CaretPosition.GetPointerContext(LogicalDirection.Backward)}\n";
                result += $"     →  : {EmojiTextBox.CaretPosition.GetPointerContext(LogicalDirection.Forward)}\n";
                result += $"\n";
                result += $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
                result += $"\n";
                result += $"Caret Adjacent Element :\n";
                result += $"    ← ← : {elementb1?.ToString()}\n";
                result += $"    ← → : {elementb2?.ToString()}\n";
                result += $"    → ← : {elementf1?.ToString()}\n";
                result += $"    → → : {elementf2?.ToString()}";
            }

            return result;
        }

        // Adapted from https://docs.microsoft.com/en-us/dotnet/api/system.windows.documents.textpointercontext
        // This method will extract and return a string that contains a representation of 
        // the XAML structure of content elements in a given TextElement.        
        private string GetXaml(FlowDocument document)
        {
            StringBuilder buffer = new StringBuilder();

            // Position a "navigator" pointer before the opening tag of the element.
            TextPointer navigator = document.ContentStart;
            int indent = 0;

            while (navigator.CompareTo(document.ContentEnd) < 0)
            {
                switch (navigator.GetPointerContext(LogicalDirection.Forward))
                {
                    case TextPointerContext.ElementStart:
                        // Output opening tag of a TextElement
                        buffer.Append(Environment.NewLine);
                        buffer.Append(' ', indent);
                        buffer.AppendFormat("<{0}>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name);
                        indent += 4;
                        break;
                    case TextPointerContext.ElementEnd:
                        // Output closing tag of a TextElement
                        indent -= 4;
                        buffer.Append(Environment.NewLine);
                        buffer.Append(' ', indent);
                        buffer.AppendFormat("</{0}>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name);
                        break;
                    case TextPointerContext.EmbeddedElement:
                        // Output simple tag for embedded element
                        buffer.Append(Environment.NewLine);
                        buffer.Append(' ', indent);
                        buffer.AppendFormat("<{0}/>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name);
                        break;
                    case TextPointerContext.Text:
                        // Output the text content of this text run
                        buffer.Append(Environment.NewLine);
                        buffer.Append(' ', indent);
                        buffer.Append(navigator.GetTextInRun(LogicalDirection.Forward));
                        break;
                }

                // Advance the naviagtor to the next context position.
                navigator = navigator.GetNextContextPosition(LogicalDirection.Forward);
            }

            return buffer.ToString();
        }

        private void OnXamlChecked(object sender, RoutedEventArgs e)
        {
            m_display_method = GetXaml;
            Update();
        }

        private void OnCaretChecked(object sender, RoutedEventArgs e)
        {
            m_display_method = GetCaretContext;
            Update();
        }
    }
}
