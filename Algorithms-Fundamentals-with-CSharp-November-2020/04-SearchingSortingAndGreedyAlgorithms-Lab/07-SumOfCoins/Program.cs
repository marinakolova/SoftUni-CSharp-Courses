using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_SumOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var target = int.Parse(Console.ReadLine());

            var sortedCoins = coins
                .OrderByDescending(c => c)
                .ToList();

            var counter = 0;
            var coinsIndex = 0;
            var usedCoins = new Dictionary<int, int>();

            while (target > 0 && coinsIndex < sortedCoins.Count)
            {
                var currentCoin = sortedCoins[coinsIndex++];
                var coinsCount = target / currentCoin;

                if (coinsCount > 0)
                {
                    counter += coinsCount;
                    target -= currentCoin * coinsCount;
                    usedCoins[currentCoin] = coinsCount;
                }
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {counter}");
                foreach (var coin in usedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
