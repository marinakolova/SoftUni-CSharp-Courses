using System;

namespace _01_PartyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int companionsCount = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int totalCoins = 0;

            for (int i = 1; i <= days; i++)
            {
                totalCoins += 50;

                if (i % 10 == 0)
                {
                    companionsCount -= 2;
                }

                if (i % 15 == 0)
                {
                    companionsCount += 5;
                }

                totalCoins -= 2 * companionsCount;

                if (i % 3 == 0)
                {
                    totalCoins -= 3 * companionsCount;
                }

                if (i % 5 == 0)
                {
                    totalCoins += 20 * companionsCount;

                    if (i % 3 == 0)
                    {
                        totalCoins -= 2 * companionsCount;
                    }
                }                
            }

            int coins = totalCoins / companionsCount;

            Console.WriteLine($"{companionsCount} companions received {coins} coins each.");
        }
    }
}
