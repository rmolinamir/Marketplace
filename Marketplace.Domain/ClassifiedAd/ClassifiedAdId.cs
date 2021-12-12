using Marketplace.Framework;

namespace Marketplace.Domain.ClassifiedAd
{
    public class ClassifiedAdId : Value<ClassifiedAdId>
    {
        private readonly Guid _value;

        public ClassifiedAdId(Guid value)
        {
            if (value == default) throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");
            _value = value;
        }

        public static implicit operator Guid(ClassifiedAdId self) => self._value;

        public static implicit operator ClassifiedAdId(string value) => new (Guid.Parse(value));
        public override string ToString() => _value .ToString();
    }
}
