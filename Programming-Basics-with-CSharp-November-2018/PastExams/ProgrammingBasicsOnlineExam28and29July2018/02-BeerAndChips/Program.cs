using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beersCount = int.Parse(Console.ReadLine());
            int chipsCount = int.Parse(Console.ReadLine());

            double beerPrice = 1.20;
            double beerValue = beersCount * beerPrice;

            double chipsPrice = 0.45 * beerValue;
            double chipsValue = Math.Ceiling (chipsCount * chipsPrice);

            double totalValue = beerValue + chipsValue;
            double moneyLeft = budget - totalValue;
            double moneyNeeded = totalValue - budget;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"{name} bought a snack and has {moneyLeft:F2} leva left.");
            }

            else
            {
                Console.WriteLine($"{name} needs {moneyNeeded:F2} more leva!");
            }
        }
    }
}
