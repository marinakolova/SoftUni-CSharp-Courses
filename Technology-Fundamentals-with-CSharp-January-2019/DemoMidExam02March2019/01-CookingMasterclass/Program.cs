using System;

namespace _01_CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());

            double calculatedPrice = 0;
            double neededMoney = 0;

            double packageOfFloursToPay = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 != 0)
                {
                    packageOfFloursToPay++;
                }
            }

            double priceOfFlourToPay = packageOfFloursToPay * priceOfFlour;

            double eggsToPay = students * 10;
            double priceOfEggsToPay = eggsToPay * priceOfEgg;

            double apronsToPay = Math.Ceiling(students + 0.2 * students);
            double priceOfApronsToPay = apronsToPay * priceOfApron;

            calculatedPrice = priceOfFlourToPay + priceOfEggsToPay + priceOfApronsToPay;

            if (calculatedPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {calculatedPrice:F2}$.");
            }
            else
            {
                neededMoney = calculatedPrice - budget;
                Console.WriteLine($"{neededMoney:F2}$ more needed.");
            }
        }
    }
}
