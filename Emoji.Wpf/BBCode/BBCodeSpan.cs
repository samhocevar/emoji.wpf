using Stfu.Linq;
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

        public bool IsExpanded 
        {
            set => Inlines.OfType<BBCodeMarkupInline>().ToList().ForAll(x => x.IsVisible = value);
        }

        public string Text => string.Join("", Inlines.OfType<Run>().Select(x => x.Text));

        public BBCodeSpan()
            : base()
        {
        }

        public BBCodeSpan(BBCodeMarkup markup, string text, FlowDocument parent, BBCodeConfig config)
            : base()
        {
            Markup = markup;
            Inlines.Add(markup.CreateMarkupInline(BBCodeMarkupInlineType.Opening));
            Inlines.Add(markup.CreateTextInline(text));
            Inlines.Add(markup.CreateMarkupInline(BBCodeMarkupInlineType.Closing));
            MarkupOpen.FontSize = parent.FontSize * config.MarkupFontScale;
            MarkupClose.FontSize = parent.FontSize * config.MarkupFontScale;
            IsExpanded = true;
        }
    }
}
