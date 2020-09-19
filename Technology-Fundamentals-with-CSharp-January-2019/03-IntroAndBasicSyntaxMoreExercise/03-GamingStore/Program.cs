using System;

namespace _03_GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double price = 0;
            double totalSpent = 0;

            while (input != "Game Time" && balance > 0)
            {
                string game = input;

                switch (game)
                {
                    case "OutFall 4": price = 39.99; break;
                    case "CS: OG": price = 15.99; break;
                    case "Zplinter Zell": price = 19.99; break;
                    case "Honored 2": price = 59.99; break;
                    case "RoverWatch": price = 29.99; break;
                    case "RoverWatch Origins Edition": price = 39.99; break;                    
                }

                if (price == 0)
                {
                    Console.WriteLine("Not Found");
                }

                else if (price > balance)
                {
                    Console.WriteLine("Too Expensive");
                }

                else if (price <= balance)
                {
                    Console.WriteLine($"Bought {game}");
                    balance -= price;
                    totalSpent += price;
                }

                input = Console.ReadLine();
            }

            if (balance == 0)
            {
                Console.WriteLine("Out of money!");
            }

            else
            {
                Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${balance:F2}");
            }
        }
    }
}
