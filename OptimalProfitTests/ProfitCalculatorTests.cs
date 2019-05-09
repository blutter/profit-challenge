using FluentAssertions;
using OptimalProfit;
using System;
using Xunit;

namespace OptimalProfitTests
{
    public class ProfitCalculatorTests
    {
        [Theory]
        [InlineData(new[] {5, 10}, 5)]
        [InlineData(new[] {10, 7, 5, 8, 11, 9}, 6)]
        [InlineData(new int[] {}, 0)]
        [InlineData(new[] {1}, 0)]
        [InlineData(new[] {10, 10, 10}, 0)]
        [InlineData(new[] {10, 9, 8 }, 0)]
        [InlineData(new[] {10, 9, 0 }, 0)]
        [InlineData(new[] {10, 9, 5, 2, 8, 9, 14, 19, 0 }, 17)]
        [InlineData(new[] {10, 9, 2, 20, 28, 3, 26 }, 26)]
        public void CalculateProfits(int[] stockPrices, int optimalProfit)
        {
            var profitCalculator = new ProfitCalculator();
            var profit = profitCalculator.GetMaximumProfit(stockPrices);
            profit.Should().Be(optimalProfit);
        }

        [Theory]
        [InlineData(new[] { 5, -1 }, typeof(ArgumentOutOfRangeException))]
        [InlineData(null, typeof(ArgumentNullException))]
        public void CalculateProfitsWithInvalidInputs(int[] stockPrices, Type exceptionType)
        {
            var profitCalculator = new ProfitCalculator();
            var exception = Record.Exception(() => profitCalculator.GetMaximumProfit(stockPrices));
            exception.Should().BeOfType(exceptionType);
        }

    }
}
