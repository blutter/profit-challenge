using System.Collections.Generic;

namespace OptimalProfit
{
    public interface IProfitCalculator
    {
        int GetMaximumProfit(int[] stockPrices);
    }
}
