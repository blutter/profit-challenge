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
        public void CalculateProfits(int[] stockPrices, int optimalProfit)
        {
            var profitCalculator = new DummyProfitCalculator();
            var stockPriceList = new List<int>(stockPrices);
            var profit = profitCalculator.GetMaximumProfit(stockPriceList);
        }
    }
}
