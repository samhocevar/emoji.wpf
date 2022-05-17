using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeInline : Run
    {
        public BBCodeMarkup Markup { get; }

        public BBCodeInline()
            : base()
        {
        }

        public BBCodeInline(BBCodeMarkup markup, string text)
            : base()
        {
            Markup = markup;
            Text = text;
        }
    }
}
