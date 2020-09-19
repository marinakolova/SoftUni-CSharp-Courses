using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _12_SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";
            List<Order> orders = new List<Order>();

            string input;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern) == false)
                {
                    continue;
                }

                string customerName = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int quantity = int.Parse(match.Groups["count"].Value);
                decimal price = decimal.Parse(match.Groups["price"].Value);

                Order order = new Order(customerName, product, quantity, price);
                orders.Add(order);
            }

            foreach (Order order in orders)
            {
                Console.WriteLine(order);
            }

            decimal totalIncome = orders.Sum(o => o.TotalPrice);

            string total = $"Total income: {totalIncome:F2}";

            Console.WriteLine(total);
        }
    }

    class Order
    {
        public Order(string customerName, string product, int quantity, decimal price)
        {
            this.CustomerName = customerName;
            this.Product = product;
            this.Quantity = quantity;
            this.Price = price;
        }

        public string CustomerName { get; }

        public string Product { get; }

        public int Quantity { get; }

        public decimal Price { get; }

        public decimal TotalPrice => this.Quantity * this.Price;

        public override string ToString()
        {
            string result = $"{this.CustomerName}: {this.Product} - {this.TotalPrice:F2}";
            return result;
        }
    }
}