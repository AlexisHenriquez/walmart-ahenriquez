using System;
using walmart_ahenriquez.Domain;
using Xunit;

namespace walmart_ahenriquez.UnitTests
{
    public class SearchTermShould
    {
        [Theory]
        [InlineData("181", "181")]
        [InlineData("abba", "abba")]
        public void GetValue(string value, string expected)
        {
            SearchTerm sut = new SearchTerm(value);

            string actual = sut.GetValue();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("181", true)]
        [InlineData("abba", true)]
        [InlineData("2332", true)]
        [InlineData("asdf", false)]
        [InlineData("qwerty", false)]
        [InlineData("1234", false)]
        public void IndicateThatIsPalindromeOrNot(string value, bool expected)
        {
            SearchTerm sut = new SearchTerm(value);

            bool actual = sut.IsPalindrome();

            Assert.Equal(expected, actual);
        }
    }
}