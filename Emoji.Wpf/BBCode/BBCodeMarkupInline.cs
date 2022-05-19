using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeMarkupInline : BBCodeInline
    {
        public BBCodeMarkupInlineType Type { get; }

        public BBCodeMarkupInline()
            : base()
        {
            Foreground = new SolidColorBrush(Colors.LightGray);
        }

        public BBCodeMarkupInline(BBCodeMarkup markup, BBCodeMarkupInlineType type)
            : base(markup)
        {
            Foreground = new SolidColorBrush(Colors.LightGray);
            Type = type;
            Text = $"[{(type == BBCodeMarkupInlineType.Closing ? "/" : "")}{markup.Markup}]";
        }
    }

    public enum BBCodeMarkupInlineType
    {
        Opening,
        Closing
    }
}
