using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeShortcutCommand : ICommand
    {
#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067

        private readonly RichTextBox _owner;

        public BBCodeShortcutCommand(RichTextBox owner)
        {
            _owner = owner;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter is BBCodeMarkup markup && _owner.Selection.Start != _owner.Selection.End)
                _owner.Selection.ApplyBBCodeMarkup(markup, _owner.Document);
        }
    }
}
