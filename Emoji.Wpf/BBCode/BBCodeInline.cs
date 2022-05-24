using System;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeSpan : Span
    {
        public BBCodeMarkup Markup { get; }
        public BBCodeMarkupInline MarkupOpen { get; }
        public BBCodeMarkupInline MarkupClose { get; }
        public BBCodeTextInline MarkupText { get; }

        public BBCodeSpan()
            : base()
        {
        }

        public BBCodeSpan(BBCodeMarkup markup, string text)
            : this()
        {
            Markup = markup;
            MarkupOpen = new BBCodeMarkupInline(markup, BBCodeMarkupInlineType.Opening);
            MarkupClose = new BBCodeMarkupInline(markup, BBCodeMarkupInlineType.Closing);
            MarkupText = CreateTextInline(text);
            Inlines.Add(MarkupOpen);
            Inlines.Add(MarkupText);
            Inlines.Add(MarkupClose);
        }

        private BBCodeTextInline CreateTextInline(string text)
        {
            var result = new BBCodeTextInline(Markup, text);

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
