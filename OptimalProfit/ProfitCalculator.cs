using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptimalProfit
{
    public class ProfitCalculator : IProfitCalculator
    {
        public int GetMaximumProfit(int[] stockPrices)
        {
            var maxProfit = 0;
            var sampleBuyPrice = stockPrices[0];
            for (int i = 1; i < stockPrices.Length; ++i)
            {
                var sampleSellPrice = stockPrices[i];
                var sampleProfit = profit(sampleBuyPrice, sampleSellPrice);
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

        private int profit(int buyPrice, int sellPrice)
        {
            return sellPrice - buyPrice;
        }
    }
}
