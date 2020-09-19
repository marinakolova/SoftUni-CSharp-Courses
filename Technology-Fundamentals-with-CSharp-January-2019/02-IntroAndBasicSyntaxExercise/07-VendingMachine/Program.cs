using System;

namespace _07_VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0;

            while (input != "Start")
            {
                double money = double.Parse(input);

                if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2)
                {
                    balance += money;
                }

                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            double price = 0;

            while (input != "End")
            {
                string product = input;

                switch (product)
                {
                    case "Nuts": price = 2; break;
                    case "Water": price = 0.7; break;
                    case "Crisps": price = 1.5; break;
                    case "Soda": price = 0.8; break;
                    case "Coke": price = 1; break;                    
                }

                if (price > 0)
                {
                    if (balance >= price)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        balance -= price;
                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid product");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {balance:F2}");
        }
    }
}
