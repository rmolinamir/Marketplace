using Marketplace.Framework;

namespace Marketplace.Domain.ClassifiedAd
{
    public class ClassifiedAdText : Value<ClassifiedAdText>
    {
        //
        // Properties to handle the persistence
        //

        // Satisfy the serialization requirements 
        protected ClassifiedAdText() { }

        //
        // Domain state properties
        //

        public string Value { get; }

        internal ClassifiedAdText(string text) => Value = text;

        public static ClassifiedAdText FromString(string text) => new (text);

        public static implicit operator string(ClassifiedAdText text) => text.Value;
    }
}