# Overview

This is a solution for the problem of finding the best profit from a single buy/sell of a stock.

# Building and Running Tests

Use the following commands to build and run the tests:

    dotnet build
    dotnet test

The implementation of Kadane's algorithm to find the highest profit is in `OptimalProfit/ProfitCalculator.cs` and the relevant tests are in `OptimalProfitTests/ProfitCalculatorTests.cs`.

The tests show examples of the happy (and not so happy) paths as well as some corner cases and boundary conditions.

# A note on the use of integers for stock prices

The problem statement and sample code use integer prices. The implementation here uses the `decimal` type instead of `int` for prices to reflect the actual price as it would be listed on the ASX. An implementation using integers would be of limited use in production.

It is assumed that integers are used in the problem statement to simplify the solution for those using Javascript and its `Number` type.

# Original Problem Description

Suppose we could access yesterday's stock prices as a list, where:

* The indices are the time in minutes past trade opening time, which was 10:00am local time.
* The values are the price in dollars of the Latitude Financial stock at that time.
* So if the stock cost $5 at 11:00am, stock_prices_yesterday[60] = 5.

Write an efficient function that takes an array of stock prices and returns the best profit I could have made from 1 purchase and 1 sale of 1 Latitude Financial stock yesterday.

For example:

    var stock_prices_yesterday = [10, 7, 5, 8, 11, 9];

    get_max_profit(stock_prices_yesterday)
    # returns 6 (buying for $5 and selling for $11)

You must buy before you sell. You may not buy and sell in the same time step (at least 1 minute must pass).
