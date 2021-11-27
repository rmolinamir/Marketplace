using System;
using Xunit;
using Marketplace.Domain;

namespace Marketplace.Tests
{
    public class UserIdTest
    {
        [Fact]
        public void UserId_should_throw_error_with_default_Guid()
        {
            Assert.Throws<ArgumentNullException>(() => new UserId(default));
        }
    }
}