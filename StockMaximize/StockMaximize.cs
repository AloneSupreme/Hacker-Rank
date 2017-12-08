using System;
using System.Linq;

namespace HackerRank
{
    class StockMaximize
    {
        static void Main(string[] args)
        {
            int numberOfTests = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < numberOfTests; i++){
                int Number = Convert.ToInt32(Console.ReadLine());
                int[] WOTSharePriceArr = new int[Number];
                WOTSharePriceArr = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

                Console.WriteLine(MaximumProfit(WOTSharePriceArr));
            }
        }

        private static long MaximumProfit(int[] sharePriceArr)
        {
            int maxProfitCount = 0;
            long profit = 0L;

            for (int i = sharePriceArr.Length - 1; i > -1; i--)
            {
                if (sharePriceArr[i] >= maxProfitCount)
                {
                    maxProfitCount = sharePriceArr[i];
                }
                profit += maxProfitCount - sharePriceArr[i];
            }
            return profit;
        }
    }
}

