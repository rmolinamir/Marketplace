using Marketplace.Framework;
using System.Text.RegularExpressions;

namespace Marketplace.Domain.ClassifiedAd
{
    public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        //
        // Properties to handle the persistence
        //

        // Satisfy the serialization requirements 
        protected ClassifiedAdTitle() { }

        //
        // Domain state properties
        //

        private readonly string _value;

        public ClassifiedAdTitle(string value)
        {
            CheckValidity(value);
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

            var value = Regex.Replace(supportedTagsReplaced, "<.*?>", string.Empty);

            CheckValidity(value);

            return new ClassifiedAdTitle(value);  // Will replace anything between arrow brackets with empty strings
        }

        public static implicit operator string(ClassifiedAdTitle text) => text._value;

        private static void CheckValidity(string value)
        {
            if (value.Length > 100) throw new ArgumentOutOfRangeException(nameof(value), "Title should not be longer than 100 characters");
        }
    }
}
