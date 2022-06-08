using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    [DebuggerDisplay(@"\{BBCodeSpan: {Text}\}")]
    public class BBCodeSpan : Span
    {
        public BBCodeMarkupInline MarkupOpen => Inlines.OfType<BBCodeMarkupInline>().FirstOrDefault(x => x.Type == BBCodeMarkupInlineType.Opening);
        public BBCodeTextInline MarkupText => Inlines.OfType<BBCodeTextInline>().FirstOrDefault();
        public BBCodeMarkupInline MarkupClose => Inlines.OfType<BBCodeMarkupInline>().FirstOrDefault(x => x.Type == BBCodeMarkupInlineType.Closing);

        public BBCodeMarkup Markup { get; }

        private bool _is_expanded = false;
        public bool IsExpanded
        {
            get => _is_expanded;
            set
            {
                if (_is_expanded != value)
                {
                    _is_expanded = value;
                    foreach (var markup in Inlines.OfType<BBCodeMarkupInline>().ToList())
                        markup.IsVisible = value;
                }
            }
        }

        public string Text => string.Join("", Inlines.OfType<Run>().Select(x => x.Text));

        public BBCodeSpan()
            : base()
        {
        }

        public BBCodeSpan(BBCodeMarkup markup, string text)
            : base()
        {
            Markup = markup;
            Inlines.Add(new BBCodeMarkupInline(markup, BBCodeMarkupInlineType.Opening));
            Inlines.Add(CreateTextInline(text));
            Inlines.Add(new BBCodeMarkupInline(markup, BBCodeMarkupInlineType.Closing));
            IsExpanded = true;
        }

        private BBCodeTextInline CreateTextInline(string text)
        {
            var result = new BBCodeTextInline(text);

            if (Markup.Foreground.HasValue)
                result.Foreground = new SolidColorBrush(Markup.Foreground.Value);
            if (Markup.FontWeight.HasValue)
                result.FontWeight = Markup.FontWeight.Value;
            if (Markup.FontStyle.HasValue)
                result.FontStyle = Markup.FontStyle.Value;

            return result;
        }
    }
}
