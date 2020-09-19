using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string type = "";
            int price = 0;
            int moneySpend = 0;

            for (int i = 0; i < n; i++)
            {
                type = Console.ReadLine();

                switch (type)
                {
                    case "hoodie": price = 30; break;
                    case "keychain": price = 4; break;
                    case "T-shirt": price = 20; break;
                    case "flag": price = 15; break;
                    case "sticker": price = 1; break;
                }

                moneySpend += price;                
            }

            int moneyLeft = budget - moneySpend;
            int moneyNeeded = moneySpend - budget;

            if (budget >= moneySpend)
                Console.WriteLine($"You bought {n} items and left with {moneyLeft} lv.");
            else
                Console.WriteLine($"Not enough money, you need {moneyNeeded} more lv.");
        }
    }
}
