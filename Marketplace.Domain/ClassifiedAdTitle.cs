using Marketplace.Framework;
using System.Text.RegularExpressions;

namespace Marketplace.Domain
{
    public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        private readonly string _value;

        private ClassifiedAdTitle(string value)
        {
            if (value.Length > 100) throw new ArgumentOutOfRangeException(nameof(value), "Title should not be longer than 100 characters");
            _value = value;
        }

        public static ClassifiedAdTitle FromString(string title) => new(title);

        public static ClassifiedAdTitle FromHtml(string htmlTitle) // This is just an example of factory functions
        {
            var supportedTagsReplaced = htmlTitle
                .Replace("<i>", "*")
                .Replace("</i>", "*")
                .Replace("<b>", "**")
                .Replace("</b>", "**");

            return new ClassifiedAdTitle(Regex.Replace(supportedTagsReplaced, "<.*?>", string.Empty));  // Will replace anything between arrow brackets with empty strings:
        }
    }
}
