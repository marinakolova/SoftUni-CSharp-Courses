using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CableMerchant
{
    public class Program
    {
        private static List<int> prices;
        private static int[] bestPrices;
        
        public static void Main(string[] args)
        {
            prices = new List<int> { 0 };

            prices.AddRange(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            var connectorPrice = int.Parse(Console.ReadLine());

            bestPrices = new int[prices.Count];
            bestPrices[0] = 0;

            for (int length = 1; length < prices.Count; length++)
            {
                var bestPrice = CutCable(length, connectorPrice);

                Console.Write($"{bestPrice} ");
            }

            Console.WriteLine();
        }

        private static int CutCable(int length, int connectorPrice)
        {
            if (length == 0)
            {
                return 0;
            }

            if (bestPrices[length] != 0)
            {
                return bestPrices[length];
            }

            var bestPrice = prices[length];

            for (int i = 1; i < length; i++)
            {
                var currentPrice = prices[i]                    
                    + CutCable(length - i, connectorPrice)
                    - 2 * connectorPrice;
                
                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                }
            }

            bestPrices[length] = bestPrice;

            return bestPrice;
        }
    }
}
