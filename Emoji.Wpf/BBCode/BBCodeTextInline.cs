using System;
using System.Linq;
using System.Windows.Documents;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeTextInline : Run
    {
        public BBCodeTextInline()
            : base()
        {
        }

        public BBCodeTextInline(BBCodeMarkup markup, string text)
        {
            Text = text;
        }
    }
}
