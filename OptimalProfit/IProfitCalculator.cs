namespace OptimalProfit
{
    public interface IProfitCalculator
    {
        decimal GetMaximumProfit(decimal[] stockPrices);
    }
}
