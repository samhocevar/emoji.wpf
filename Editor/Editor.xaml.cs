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

using Emoji.Wpf;
using System;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Editor
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("Editor.xaml", UriKind.Relative);
            app.Run();
        }

        public EditorWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CodeTextBox.Text = GetXaml(EmojiTextBox.Document);
        }

        private void EmojiTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsLoaded)
                CodeTextBox.Text = GetXaml((sender as RichTextBox).Document);
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
            } // End while.

            return buffer.ToString();
        } // End GetXaml method.
    }
}
