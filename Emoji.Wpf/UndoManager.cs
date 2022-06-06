using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Emoji.Wpf
{
    internal class UndoState
    {
        public int StartPosition { get; private set; }
        public int EndPosition { get; private set; }
        private byte[] _data;

        public UndoState(RichTextBox rtb)
        {
            using (var stream = new MemoryStream())
            {
                XamlWriter.Save(rtb.Document, stream);
                _data = stream.ToArray();
                EndPosition = rtb.Document.ContentStart.GetOffsetToPosition(rtb.CaretPosition);
                StartPosition = EndPosition - 1;
            }
        }

        public void Update(RichTextBox rtb)
        {
            using (var stream = new MemoryStream())
            {
                XamlWriter.Save(rtb.Document, stream);
                _data = stream.ToArray();
                EndPosition = rtb.Document.ContentStart.GetOffsetToPosition(rtb.CaretPosition);
            }
        }

        public void Load(RichTextBox rtb)
        {
            using (var stream = new MemoryStream(_data))
                rtb.Document = XamlReader.Load(stream) as FlowDocument;
        }
    }

    public class UndoManager
    {
        private List<UndoState> _states = new List<UndoState>(100);
        private int _current = -1;

        /// <summary>
        /// Update the undo history according to the undo action after text changed.
        /// </summary>
        public void Update(RichTextBox rtb, UndoAction undo_action)
        {
            switch (undo_action)
            {
                case UndoAction.Create:
                    CreateState(rtb);
                    break;
                case UndoAction.Merge:
                    UpdateCurrentState(rtb);
                    break;
                case UndoAction.Clear:
                    ClearStates(rtb);
                    break;
            }
        }

        /// <summary>
        /// Returns whether the undo operation can be performed.
        /// </summary>
        public bool CanUndo() => _current > 0;

        /// <summary>
        /// Returns whether the redo operation can be performed.
        /// </summary>
        public bool CanRedo() => _current < _states.Count - 1;

        /// <summary>
        /// Performs undo on a <see cref="RichTextBox"/>
        /// </summary>
        public void Undo(RichTextBox rtb)
        {
            if (CanUndo())
            {
                _current--;
                _states[_current].Load(rtb);
                rtb.CaretPosition = rtb.Document.ContentStart.GetPositionAtOffset(_states[_current + 1].StartPosition);
            }
        }

        /// <summary>
        /// Performs redo on a <see cref="RichTextBox"/>
        /// </summary>
        public void Redo(RichTextBox rtb)
        {
            if (CanRedo())
            {
                _current++;
                _states[_current].Load(rtb);
                rtb.CaretPosition = rtb.Document.ContentStart.GetPositionAtOffset(_states[_current].EndPosition);
            }
        }

        /// <summary>
        /// Add a new undo state and move the current state pointer.
        /// </summary>
        private void CreateState(RichTextBox rtb)
        {
            if (_current < _states.Count - 1)
            {
                var range_start = _current + 1;
                var range_length = _states.Count - range_start;
                _states.RemoveRange(range_start, range_length);
            }
            _states.Add(new UndoState(rtb));
            _current = _states.Count - 1;
        }

        /// <summary>
        /// Override current undo state with a new one.
        /// </summary>
        private void UpdateCurrentState(RichTextBox rtb)
        {
            if (_current >= 0 && _current < _states.Count)
                _states[_current].Update(rtb);
        }

        /// <summary>
        /// Clear all undo states and create a base undo state.
        /// </summary>
        private void ClearStates(RichTextBox rtb)
        {
            _states.Clear();
            _current = -1;
            CreateState(rtb);
        }
    }
}
