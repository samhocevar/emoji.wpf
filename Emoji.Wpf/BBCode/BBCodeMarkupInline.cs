using System;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeMarkupInline : Run
    {
        public BBCodeMarkupInlineType Type { get; }

        public BBCodeMarkupInline()
            : base()
        {
            Foreground = new SolidColorBrush(Colors.LightGray);
        }

        public BBCodeMarkupInline(BBCodeMarkup markup, BBCodeMarkupInlineType type)
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
