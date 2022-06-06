using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    [DebuggerDisplay(@"\{BBCodeMarkupInline: {Text}\}")]
    public class BBCodeMarkupInline : Run
    {
        public readonly BBCodeMarkupInlineType Type;

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
