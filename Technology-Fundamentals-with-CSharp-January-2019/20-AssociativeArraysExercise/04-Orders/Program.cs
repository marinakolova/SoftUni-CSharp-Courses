using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, double[]>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] data = input.Split().ToArray();

                string product = data[0];
                double price = double.Parse(data[1]);
                double quantity = double.Parse(data[2]);

                if (!products.ContainsKey(product))
                {
                    products.Add(product, new double[2]);
                }

                products[product][0] = price;
                products[product][1] += quantity;
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
            }
        }
    }
}
