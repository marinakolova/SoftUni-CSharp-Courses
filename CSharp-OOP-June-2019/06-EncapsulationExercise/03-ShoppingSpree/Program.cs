using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var people = new List<Person>();
            foreach (var partOfInput in peopleInput)
            {
                var personData = partOfInput.Split("=");
                var name = personData[0];
                var money = double.Parse(personData[1]);
                try
                {
                    people.Add(new Person(name, money));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Environment.Exit(0);
                }
            }

            var productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var products = new List<Product>();
            foreach (var partOfInput in productsInput)
            {
                var productData = partOfInput.Split("=");
                var name = productData[0];
                var price = double.Parse(productData[1]);
                try
                {
                    products.Add(new Product(name, price));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Environment.Exit(0);
                }
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = partsOfCommand[0];
                var productName = partsOfCommand[1];
                
                if (people.Where(p => p.Name == personName).FirstOrDefault() != null
                    && products.Where(p => p.Name == productName).FirstOrDefault() != null)
                {
                    if (people.Where(p => p.Name == personName).FirstOrDefault().Money
                        >= products.Where(p => p.Name == productName).FirstOrDefault().Price)
                    {
                        people.Where(p => p.Name == personName).FirstOrDefault().Money
                            -= products.Where(p => p.Name == productName).FirstOrDefault().Price;
                        people.Where(p => p.Name == personName).FirstOrDefault().BagOfProducts
                            .Add(products.Where(p => p.Name == productName).FirstOrDefault());
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                }
            }

            if (people.Count > 0)
            {
                foreach (var p in people)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
