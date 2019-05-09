using System;
using System.Linq;

namespace OptimalProfit
{
    public class ProfitCalculator : IProfitCalculator
    {
        public int GetMaximumProfit(int[] stockPrices)
        {
            ValidateStockPrices(stockPrices);

            var maxProfit = 0;
            var sampleBuyPrice = stockPrices[0];
            for (int i = 1; i < stockPrices.Length; ++i)
            {
                var sampleSellPrice = stockPrices[i];
                var sampleProfit = CalculateProfit(sampleBuyPrice, sampleSellPrice);
                if (sampleProfit > maxProfit)
                {
                    maxProfit = sampleProfit;
                }

                if (sampleBuyPrice > sampleSellPrice)
                {
                    sampleBuyPrice = stockPrices[i];
                }
            }

            return maxProfit;
        }

        private int CalculateProfit(int buyPrice, int sellPrice)
        {
            return sellPrice - buyPrice;
        }

        private void ValidateStockPrices(int[] stockPrices)
        {
            if (stockPrices == null)
            {
                throw new ArgumentNullException();
            }
            else if (stockPrices.Any(price => price < 0))
            {
                throw new ArgumentOutOfRangeException("Stock prices must be positive or zero values");
            }
        }
    }
}
