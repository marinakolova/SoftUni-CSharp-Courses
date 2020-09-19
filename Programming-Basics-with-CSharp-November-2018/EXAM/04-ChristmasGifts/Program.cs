using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ChristmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int adults = 0;
            int kids = 0;
            string command = "";
            int age = 0;

            command = Console.ReadLine();

            while (command != "Christmas")
            {
                age = int.Parse(command);

                if (age <= 16)
                    kids++;
                else if (age > 16)
                    adults++;

                command = Console.ReadLine();
            }

            double moneyForToys = kids * 5;
            double moneyForSweaters = adults * 15;

            Console.WriteLine($"Number of adults: {adults}");
            Console.WriteLine($"Number of kids: {kids}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
        }
    }
}
