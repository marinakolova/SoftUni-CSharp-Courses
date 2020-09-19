using System;
using System.Collections.Generic;
using System.Text;

namespace _03_ShoppingSpree
{
    public class Product
    {
        private string name;
        private double price;

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

        public double Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.price = value;
            }
        }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
