using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Domain;
using Xunit;

namespace walmart_ahenriquez.UnitTests
{
    public class ProductShould
    {
        [Theory]
        [InlineData(1000, 500, 0.5)]
        [InlineData(2000, 1000, 0.5)]
        [InlineData(1000, 750, 0.25)]
        [InlineData(2000, 1500, 0.25)]
        [InlineData(9990, 4995, 0.5)]
        [InlineData(26990, 13495, 0.5)]
        [InlineData(9999, 5000, 0.5)]
        [InlineData(26999, 13500, 0.5)]
        public void GetPriceWithAppliedDiscount(double price, double expected, double discountRate)
        {
            Product sut = new Product() { Price = price };

            double actual = sut.GetPriceWithDiscount(discountRate);

            Assert.Equal(expected, actual);
        }
    }
}
