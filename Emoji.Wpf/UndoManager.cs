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
        private int _data_length;

        public UndoState(RichTextBox rtb)
        {
            var stream = new MemoryStream();
            XamlWriter.Save(rtb.Document, stream);
            _data_length = (int)stream.Length;
            _data = new byte[(int)(_data_length * 1.5)];
            var data_stream = new MemoryStream(_data);
            stream.WriteTo(data_stream);
            StartPosition = rtb.LastCaretPosition;
            EndPosition = rtb.GetCaretPosition();
        }

        public void Update(RichTextBox rtb)
        {
            var stream = new MemoryStream();
            XamlWriter.Save(rtb.Document, stream);
            _data_length = (int)stream.Length;
            if (_data.LongLength < _data_length)
                Array.Resize(ref _data, (int)(_data_length * 1.5));
            var data_stream = new MemoryStream(_data);
            stream.WriteTo(data_stream);
            EndPosition = rtb.GetCaretPosition();
        }

        public void Load(RichTextBox rtb)
        {
            var stream = new MemoryStream(_data, 0, _data_length);
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
                rtb.SetCaretPosition(_states[_current + 1].StartPosition);
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
                rtb.SetCaretPosition(_states[_current].EndPosition);
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
