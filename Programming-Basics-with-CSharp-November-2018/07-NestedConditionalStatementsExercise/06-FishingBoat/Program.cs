using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double people = double.Parse(Console.ReadLine());

            int shipRent = 0;

            if (season == "Spring")
                shipRent = 3000;
            else if (season == "Summer" || season == "Autumn")
                shipRent = 4200;
            else if (season == "Winter")
                shipRent = 2600;

            double shipRentWithDiscount = 0;

            if (people <= 6)
                shipRentWithDiscount = shipRent - 0.10 * shipRent;
            else if (people >= 7 && people <= 11)
                shipRentWithDiscount = shipRent - 0.15 * shipRent;
            else if (people >= 12)
                shipRentWithDiscount = shipRent - 0.25 * shipRent;

            double shipRentWithDiscount2 = 0;

            if (people % 2 == 0 && season != "Autumn")
                shipRentWithDiscount2 = shipRentWithDiscount - 0.05 * shipRentWithDiscount;
            else
                shipRentWithDiscount2 = shipRentWithDiscount;

            double moneyLeft = budget - shipRentWithDiscount2;
            double moneyNeeded = shipRentWithDiscount2 - budget;

            if (moneyLeft >= 0)
                Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
            else
                Console.WriteLine($"Not enough money! You need {moneyNeeded:F2} leva.");
        }
    }
}
