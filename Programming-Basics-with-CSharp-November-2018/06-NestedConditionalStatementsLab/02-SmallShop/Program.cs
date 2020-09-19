using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());

            if (town == "Sofia" && product == "coffee")
                Console.WriteLine(0.50 * count);
            else if (town == "Sofia" && product == "water")
                Console.WriteLine(0.80 * count);
            else if (town == "Sofia" && product == "beer")
                Console.WriteLine(1.20 * count);
            else if (town == "Sofia" && product == "sweets")
                Console.WriteLine(1.45 * count);
            else if (town == "Sofia" && product == "peanuts")
                Console.WriteLine(1.60 * count);

            else if (town == "Plovdiv" && product == "coffee")
                Console.WriteLine(0.40 * count);
            else if (town == "Plovdiv" && product == "water")
                Console.WriteLine(0.70 * count);
            else if (town == "Plovdiv" && product == "beer")
                Console.WriteLine(1.15 * count);
            else if (town == "Plovdiv" && product == "sweets")
                Console.WriteLine(1.30 * count);
            else if (town == "Plovdiv" && product == "peanuts")
                Console.WriteLine(1.50 * count);

            else if (town == "Varna" && product == "coffee")
                Console.WriteLine(0.45 * count);
            else if (town == "Varna" && product == "water")
                Console.WriteLine(0.70 * count);
            else if (town == "Varna" && product == "beer")
                Console.WriteLine(1.10 * count);
            else if (town == "Varna" && product == "sweets")
                Console.WriteLine(1.35 * count);
            else if (town == "Varna" && product == "peanuts")
                Console.WriteLine(1.55 * count);
        }
    }
}
