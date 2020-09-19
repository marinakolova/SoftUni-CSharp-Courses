using System;
using System.Collections.Generic;

namespace _05_ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(';');

            foreach (var person in peopleInput)
            {
                string name = person.Split('=')[0];
                decimal money = decimal.Parse(person.Split('=')[1]);
                people.Add(new Person(name, money));
            }

            string[] productsInput = Console.ReadLine().Split(';');

            foreach (var product in productsInput)
            {
                string name = product.Split('=')[0];
                decimal price = decimal.Parse(product.Split('=')[1]);
                products.Add(new Product(name, price));
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string personsName = command.Split()[0];
                string productName = command.Split()[1];


                people.Find(p => p.Name == personsName).BuyProduct(products.Find(p => p.Name == productName));

                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<string> Bag { get; set; } = new List<string>();

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
        }

        public void BuyProduct(Product productToBuy)
        {
            if (this.Money >= productToBuy.Price)
            {
                this.Bag.Add(productToBuy.Name);
                this.Money -= productToBuy.Price;
                Console.WriteLine($"{this.Name} bought {productToBuy.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {productToBuy.Name}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}