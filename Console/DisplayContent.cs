using System;
using homepage.Enums;

namespace homepage.Console
{
    public class DisplayContent
    {
        public string Content { get; set; }
        public bool LineBreak { get; set; }
        public string Color { get; set; }
        public bool Bold { get; set; }

        public DisplayContent(string content, bool lineBreak = false, string color = "", bool bold = false)
        {
            Content = content;
            LineBreak = lineBreak;
            Color = String.IsNullOrEmpty(color) ? Colors.Default : color;
            Bold = bold;
        }

        public string ToMarkup()
        {
            var classes = "" + Color;
            if (Bold)
                classes += " font-bold";
            var br = LineBreak ? "<br>" : "";
            return $"<span class={classes}>{Content}</span>{br}";
        }

        public override string ToString()
         => Content;
    }

}