using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class Money : Value<Money>
    {
        public decimal Amount { get; }

        protected Money(decimal amount)
        {
            if (decimal.Round(amount, 2) != amount) throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot have more than two decimals");
            Amount = amount;
        }

        public Money Add(Money summand) => new(Amount + summand.Amount);

        public Money Substract(Money subtrahend) => new(Amount - subtrahend.Amount);

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public static Money operator -(Money minuend, Money subtrahend2) => minuend.Substract(subtrahend2);

        public static Money FromDecimal(decimal amount) => new(amount);

        public static Money FromString(string amount) => new(decimal.Parse(amount));

    }
}
