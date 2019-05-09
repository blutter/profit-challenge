using OptimalProfit;
using System.Collections.Generic;
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
            var profitCalculator = new DummyProfitCalculator();
            var stockPriceList = new List<int>(stockPrices);
            var profit = profitCalculator.GetMaximumProfit(stockPriceList);
        }
    }
}
