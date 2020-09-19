using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string outfit = string.Empty;
            string shoes = string.Empty;

            if (degrees >= 10 && degrees <= 18 && time == "Morning")
            {
                outfit = "Sweatshirt";
                shoes = "Sneakers";
            }

            else if (degrees >= 10 && degrees <= 18 && time == "Afternoon")
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }

            else if (degrees >= 10 && degrees <= 18 && time == "Evening")
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }

            else if (degrees > 18 && degrees <= 24 && time == "Morning")
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }

            else if (degrees > 18 && degrees <= 24 && time == "Afternoon")
            {
                outfit = "T-Shirt";
                shoes = "Sandals";
            }

            else if (degrees > 18 && degrees <= 24 && time == "Evening")
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }

            else if (degrees >= 25 && time == "Morning")
            {
                outfit = "T-Shirt";
                shoes = "Sandals";
            }

            else if (degrees >= 25 && time == "Afternoon")
            {
                outfit = "Swim Suit";
                shoes = "Barefoot";
            }

            else if (degrees >= 25 && time == "Evening")
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
