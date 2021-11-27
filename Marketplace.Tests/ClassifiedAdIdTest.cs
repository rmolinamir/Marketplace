using System;
using Xunit;
using Marketplace.Domain;

namespace Marketplace.Tests
{
    public class ClassifiedAdIdTest
    {
        [Fact]
        public void ClassifiedAdId_should_throw_error_with_default_Guid()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassifiedAdId(default));
        }
    }
}