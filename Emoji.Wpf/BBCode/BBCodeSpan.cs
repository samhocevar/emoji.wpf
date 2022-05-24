using System;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;

namespace Emoji.Wpf.BBCode
{
    public class BBCodeSpan : Span
    {
        public BBCodeMarkup Markup { get; }

        //public BBCodeMarkupInline MarkupOpen => Inlines.ElementAtOrDefault(0) as BBCodeMarkupInline;
        //public BBCodeTextInline MarkupText => Inlines.ElementAtOrDefault(1) as BBCodeTextInline;
        //public BBCodeMarkupInline MarkupClose => Inlines.ElementAtOrDefault(2) as BBCodeMarkupInline;

        public string Text => String.Join("", Inlines.OfType<Run>().Select(x => x.Text));

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
        }

        public BBCodeSpan(TextPointer insertionPosition, BBCodeMarkup markup, string text)
            : base((Run)null, insertionPosition)
        {
            Markup = markup;
            Inlines.Add(new BBCodeMarkupInline(markup, BBCodeMarkupInlineType.Opening));
            Inlines.Add(CreateTextInline(text));
            Inlines.Add(new BBCodeMarkupInline(markup, BBCodeMarkupInlineType.Closing));
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
