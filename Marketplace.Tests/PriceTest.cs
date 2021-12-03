using System;
using Xunit;
using Marketplace.Domain;

namespace Marketplace.Tests
{
    public class PriceTest
    {
        [Fact]
        public void Price_should_throw_error_with_negative_amount()
        {
            Assert.Throws<ArgumentException>(() => new Price(-10, "EUR", CurrencyLookp));
        }

        public static ICurrencyLookup CurrencyLookp = new FakeCurrencyLookup();
    }
}