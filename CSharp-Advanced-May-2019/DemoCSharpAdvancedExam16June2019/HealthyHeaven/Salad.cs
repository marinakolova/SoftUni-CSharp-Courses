using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public string Name { get; set; }

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            int sum = 0;

            foreach (var vegetable in products)
            {
                sum += vegetable.Calories;
            }

            return sum;
        }

        public int GetProductCount()
        {
            return products.Count;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            for (int i = 0; i < this.products.Count - 1; i++)
            {
                sb.AppendLine($"{this.products[i].ToString()}");
            }

            sb.Append($"{this.products[this.products.Count - 1].ToString()}");

            return sb.ToString();
        }
    }
}
