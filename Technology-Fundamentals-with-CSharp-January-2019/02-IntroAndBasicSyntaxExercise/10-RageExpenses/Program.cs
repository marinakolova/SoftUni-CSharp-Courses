using System;

namespace _10_RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double expenses = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 12 == 0)
                    expenses += displayPrice;
                if (i % 6 == 0)
                    expenses += keyboardPrice;
                if (i % 3 == 0)
                    expenses += mousePrice;
                if (i % 2 == 0)
                    expenses += headsetPrice;
            }

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
