using System;
using System.Linq;

namespace OptimalProfit
{
    public class ProfitCalculator : IProfitCalculator
    {
        /// <summary>
        /// Calculate the maximum profit for a single buy/sell using Kandane's algorithm
        /// </summary>
        /// <param name="stockPrices">Array of stock prices in chronological order</param>
        /// <returns>The maximum profit</returns>
        public decimal GetMaximumProfit(decimal[] stockPrices)
        {
            ValidateStockPrices(stockPrices);

            decimal maxProfit = 0;
            var potentialBuyPrice = stockPrices.FirstOrDefault();
            for (int i = 1; i < stockPrices.Length; ++i)
            {
                var potentialSellPrice = stockPrices[i];
                var potentialProfit = CalculateProfit(potentialBuyPrice, potentialSellPrice);
                if (potentialProfit > maxProfit)
                {
                    maxProfit = potentialProfit;
                }

                if (potentialBuyPrice > potentialSellPrice)
                {
                    potentialBuyPrice = stockPrices[i];
                }
            }

            return maxProfit;
        }

        private decimal CalculateProfit(decimal buyPrice, decimal sellPrice)
        {
            return sellPrice - buyPrice;
        }

        private void ValidateStockPrices(decimal[] stockPrices)
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
