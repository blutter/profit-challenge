using FluentAssertions;
using OptimalProfit;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace OptimalProfitTests
{
    public class ProfitCalculatorTests
    {
        [Theory]
        [ClassData(typeof(ProfitCalculatorDataGenerator))]
        public void CalculateProfits(decimal[] stockPrices, decimal optimalProfit)
        {
            var profitCalculator = new ProfitCalculator();
            var profit = profitCalculator.GetMaximumProfit(stockPrices);
            profit.Should().Be(optimalProfit);
        }

        [Theory]
        [ClassData(typeof(ProfitCalculatorInvalidDataGenerator))]
        [InlineData(null, typeof(ArgumentNullException))]
        public void CalculateProfitsWithInvalidInputs(decimal[] stockPrices, Type exceptionType)
        {
            var profitCalculator = new ProfitCalculator();
            var exception = Record.Exception(() => profitCalculator.GetMaximumProfit(stockPrices));
            exception.Should().BeOfType(exceptionType);
        }

    }

    public class ProfitCalculatorDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new[] {5m, 10m}, 5m },
            new object[] { new[] {10m, 7m, 5m, 8m, 11m, 9m}, 6m},
            // No trades in the day
            new object[] { new decimal[] {}, 0m},
            // Only one trade in the day
            new object[] { new[] {1m}, 0m},
            new object[] { new[] {0m}, 0m},
            // Trades all the same price
            new object[] { new[] {10m, 10m, 10m}, 0m},
            // Bear market: Trades are all in decreasing price
            new object[] { new[] {10m, 9m, 8m }, 0m},
            new object[] { new[] {10m, 9m, 0m }, 0m},
            // Fluctuating prices
            new object[] { new[] {10m, 9m, 5m, 2m, 8m, 9m, 14m, 19m, 0m }, 17m},
            new object[] { new[] {10m, 9m, 2m, 20m, 28m, 3m, 26m }, 26m},
            // Trades with cents
            new object[] { new[] { 10.01m, 10.02m, 20.10m }, 10.09m},
            // Trade in a penny stock with fractional cents
            new object[] { new[] { 0.10m, 5.025m, 5.02m }, 4.925m}

        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ProfitCalculatorInvalidDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new[] { 5.0m, -1.0m }, typeof(ArgumentOutOfRangeException) },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
