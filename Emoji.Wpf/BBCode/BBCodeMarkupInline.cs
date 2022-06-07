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
        public BBCodeMarkupInlineType Type { get; set; }
        public string Markup { get; set; }

        private bool _is_visible = false;
        public bool IsVisible
        {
            get => _is_visible;
            set
            {
                if (_is_visible != value)
                {
                    _is_visible = value;
                    Text = _is_visible ? $"[{(Type == BBCodeMarkupInlineType.Closing ? "/" : "")}{Markup}]" : "";
                }

            }
        }

        public BBCodeMarkupInline()
            : base()
        {
            Foreground = new SolidColorBrush(Colors.LightGray);
        }

        public BBCodeMarkupInline(BBCodeMarkup markup, BBCodeMarkupInlineType type)
        {
            Markup = markup.Markup;
            Type = type;
            Foreground = new SolidColorBrush(Colors.LightGray);
            IsVisible = true;
        }
    }

    public enum BBCodeMarkupInlineType
    {
        Opening,
        Closing
    }
}
