using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string type = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double price = 0;
            double total = 0;

            if (team == "Argentina")
            {
                switch (type)
                {
                    case "flags": price = 3.25; break;
                    case "caps": price = 7.20; break;
                    case "posters": price = 5.10; break;
                    case "stickers": price = 1.25; break;
                }

                total = price * count;

                if (price == 0)
                    Console.WriteLine("Invalid stock!");
                else
                    Console.WriteLine($"Pepi bought {count} {type} of {team} for {total:F2} lv.");
            }

            else if (team == "Brazil")
            {
                switch (type)
                {
                    case "flags": price = 4.20; break;
                    case "caps": price = 8.50; break;
                    case "posters": price = 5.35; break;
                    case "stickers": price = 1.20; break;
                }

                total = price * count;

                if (price == 0)
                    Console.WriteLine("Invalid stock!");
                else
                    Console.WriteLine($"Pepi bought {count} {type} of {team} for {total:F2} lv.");
            }

            else if (team == "Croatia")
            {
                switch (type)
                {
                    case "flags": price = 2.75; break;
                    case "caps": price = 6.90; break;
                    case "posters": price = 4.95; break;
                    case "stickers": price = 1.10; break;
                }

                total = price * count;

                if (price == 0)
                    Console.WriteLine("Invalid stock!");
                else
                    Console.WriteLine($"Pepi bought {count} {type} of {team} for {total:F2} lv.");
            }

            else if (team == "Denmark")
            {
                switch (type)
                {
                    case "flags": price = 3.10; break;
                    case "caps": price = 6.50; break;
                    case "posters": price = 4.80; break;
                    case "stickers": price = 0.90; break;
                }

                total = price * count;

                if (price == 0)
                    Console.WriteLine("Invalid stock!");
                else
                    Console.WriteLine($"Pepi bought {count} {type} of {team} for {total:F2} lv.");
            }

            else
            {
                Console.WriteLine("Invalid country!");
            }
        }
    }
}
