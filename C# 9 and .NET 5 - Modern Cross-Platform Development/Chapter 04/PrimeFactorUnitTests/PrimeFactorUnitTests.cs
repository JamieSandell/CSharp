using Packt;
using System;
using Xunit;

namespace PrimeFactorLibUnitTests
{
    public class PrimeFactorUnitTests
    {
        [Fact]
        public void TestPrimeFactor7()
        {
            // arrange
            int a = 7;
            string expected = "7";
            var pf = new PrimeFactorsLib();
            // act
            string actual = pf.PrimeFactors(a);
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPrimeFactor50()
        {
            // arrange
            int a = 50;
            string expected = "2 x 5 x 5";
            var pf = new PrimeFactorsLib();
            // act
            string actual = pf.PrimeFactors(a);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
