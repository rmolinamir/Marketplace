using Marketplace.Framework;

namespace Marketplace.Domain.Shared
{
    public class Money : Value<Money>
    {
        private const string DefaultCurrency = "EUR";

        public decimal Amount { get; }

        public CurrencyDetails Currency { get; }

        protected Money(decimal amount, string currencyCode, ICurrencyLookup currencyLookup)
        {
            if (string.IsNullOrEmpty(currencyCode)) throw new ArgumentNullException(nameof(currencyCode), "Currency code must be specified");
    
            var currency = currencyLookup.FindCurrency(currencyCode);

            if (!currency.InUse) throw new ArgumentException($"Currency {currencyCode} is not valid");

            var roundedAmount = decimal.Round(amount, currency.DecimalPlaces);

            if (roundedAmount != amount) throw new ArgumentOutOfRangeException(nameof(amount), $"Amount in {currencyCode} cannot have more than {currency.DecimalPlaces} decimals");

            Amount = amount;
            Currency = currency;
        }

        protected Money(decimal amount, CurrencyDetails currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money summand)
        {
            if (Currency != summand.Currency) throw new CurrencyMismatchException("Cannot sum amounts with different currencies");
            return new(Amount + summand.Amount, Currency);
        }

        public Money Substract(Money subtrahend)
        {
            if (Currency != subtrahend.Currency) throw new CurrencyMismatchException("Cannot substract amounts with different currencies");
            return new(Amount - subtrahend.Amount, Currency);
        }

        public override string ToString() => $"{Currency.CurrencyCode}{Amount}";

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public static Money operator -(Money minuend, Money subtrahend2) => minuend.Substract(subtrahend2);

        public static Money FromString(string amount, string currencyCode, ICurrencyLookup currencyLookup) => new(decimal.Parse(amount), currencyCode, currencyLookup);

        public static Money FromDecimal(decimal amount, string currencyCode, ICurrencyLookup currencyLookup) => new(amount, currencyCode, currencyLookup);

    }

    public class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) : base(message) { }
    }
}
