using System;
using System.Collections.Generic;

namespace _03_ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Revision")
                {
                    break;
                }

                var partsOfInput = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var shop = partsOfInput[0];
                var product = partsOfInput[1];
                var price = double.Parse(partsOfInput[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, price);
                }
            }

            foreach (var item in shops)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var stock in item.Value)
                {
                    Console.WriteLine($"Product: {stock.Key}, Price: {stock.Value}");
                }
            }
        }
    }
}
