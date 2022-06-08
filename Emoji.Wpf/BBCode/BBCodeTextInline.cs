using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;

namespace Emoji.Wpf.BBCode
{
    [DebuggerDisplay(@"\{BBCodeTextInline: {Text}\}")]
    public class BBCodeTextInline : Run
    {
        public BBCodeTextInline()
            : base()
        {
        }

        public BBCodeTextInline(string text)
        {
            Text = text;
        }
    }
}
