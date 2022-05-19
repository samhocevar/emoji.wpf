using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeTextInline : BBCodeInline
    {
        public BBCodeTextInline()
            : base()
        {
        }

        public BBCodeTextInline(BBCodeMarkup markup, string text)
            : base(markup)
        {
            Text = text;
        }
    }
}
