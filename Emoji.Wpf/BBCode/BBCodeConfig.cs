using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emoji.Wpf.BBCode
{
    /// <summary>
    /// Configuration class for an Emoji RichTextBox supporting BBCode
    /// </summary>
    public class BBCodeConfig
    {
        /// <summary>
        /// List of BBCode markup definitions
        /// </summary>
        public List<BBCodeMarkup> Markups { get; set; }
    }
}
