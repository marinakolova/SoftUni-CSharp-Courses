using System;
using System.Collections.Generic;
using System.Text;

namespace _04_PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private List<string> validTypes = new List<string> { "meat", "veggies", "cheese", "sauce"};

        private string type;
        private double weight;

        public string Type
        {
            get => this.type;
            set
            {
                if (!validTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(" weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double CalculateCalories()
        {
            var modifier = 1.0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;

                case "veggies":
                    modifier = 0.8;
                    break;

                case "cheese":
                    modifier = 1.1;
                    break;

                case "sauce":
                    modifier = 0.9;
                    break;
            }

            return BaseCaloriesPerGram * this.weight * modifier;
        }
    }
}
