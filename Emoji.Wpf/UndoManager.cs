using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Markup;

namespace Emoji.Wpf
{
    public class UndoManager<T>
    {
        private List<byte[]> m_changes_history = new List<byte[]>(100);
        private int m_current = -1;

        /// <summary>
        /// Add a new undo state and move the current state pointer.
        /// </summary>
        /// <param name="obj">Object that will be serialized in the state.</param>
        public void Create(T obj)
        {
            using (var stream = new MemoryStream(2000))
            {
                if (m_current < m_changes_history.Count - 1)
                {
                    var range_start = m_current + 1;
                    var range_length = m_changes_history.Count - range_start;
                    m_changes_history.RemoveRange(range_start, range_length);
                }
                XamlWriter.Save(obj, stream);
                m_changes_history.Add(stream.ToArray());
                m_current = m_changes_history.Count - 1;
            }
        }

        /// <summary>
        /// Override current undo state with a new one.
        /// </summary>
        /// <param name="obj">Object that will be serialized in the state.</param>
        public void UpdateCurrent(T obj)
        {
            using (var stream = new MemoryStream(2000))
            {
                XamlWriter.Save(obj, stream);
                m_changes_history[m_current] = stream.ToArray();
            }
        }

        /// <summary>
        /// Clear all undo states and create a base undo state.
        /// </summary>
        /// <param name="obj">Object that will be serialized in the base state.</param>
        public void Clear(T obj)
        {
            m_changes_history.Clear();
            m_current = -1;
            Create(obj);
        }

        /// <summary>
        /// Returns whether the undo operation can be performed.
        /// </summary>
        public bool CanUndo() => m_current > 0;

        /// <summary>
        /// Returns whether the redo operation can be performed.
        /// </summary>
        public bool CanRedo() => m_current < m_changes_history.Count - 1;

        /// <summary>
        /// Gets the last undo state object value.
        /// </summary>
        /// <param name="obj">When this method returns, contains the new object state,
        /// otherwise, the default value for the type of the value parameter.
        /// This parameter is passed uninitialized.</param>
        /// <returns>true if the undo was successful, false otherwise.</returns>
        public bool TryUndo(out T obj)
        {
            if (CanUndo())
            {
                m_current--;
                using (var stream = new MemoryStream(m_changes_history[m_current]))
                {
                    var untyped_obj = XamlReader.Load(stream);
                    if (untyped_obj is T)
                    {
                        obj = (T)untyped_obj;
                        return true;
                    }
                }
            }
            obj = default(T);
            return false;
        }

        /// <summary>
        /// Gets the next undo state object value.
        /// </summary>
        /// <param name="obj">When this method returns, contains the new object state,
        /// otherwise, the default value for the type of the value parameter.
        /// This parameter is passed uninitialized.</param>
        /// <returns>true if the undo was successful, false otherwise.</returns>
        public bool TryRedo(out T obj)
        {
            if (CanRedo())
            {
                m_current++;
                using (var stream = new MemoryStream(m_changes_history[m_current]))
                {
                    var untyped_obj = XamlReader.Load(stream);
                    if (untyped_obj is T)
                    {
                        obj = (T)untyped_obj;
                        return true;
                    }
                }
            }
            obj = default(T);
            return false;
        }
    }
}
