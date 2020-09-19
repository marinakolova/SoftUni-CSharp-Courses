using System;

namespace _09_SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int dailySpice = 0;
            int totalSpice = 0;

            while (yield >= 100)
            {
                days += 1;
                dailySpice += yield;

                yield -= 10;

                dailySpice -= 26;
                totalSpice += dailySpice;
                dailySpice = 0;
            }

            totalSpice -= 26;

            if (totalSpice < 0)
            {
                totalSpice = 0;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
