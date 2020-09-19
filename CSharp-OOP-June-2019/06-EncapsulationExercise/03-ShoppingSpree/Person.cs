using System;
using System.Collections.Generic;
using System.Text;

namespace _03_ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;

        public string Name
        {
            get => this.name;
            set
            {
                if (value == "" || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> BagOfProducts { get; set; }

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public override string ToString()
        {
            if (this.BagOfProducts.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.BagOfProducts)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
