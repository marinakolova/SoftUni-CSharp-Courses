using System;
using System.Collections.Generic;
using System.Text;

namespace _04_PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppingsCount = 10;

        private string name;

        public string Name
        {
            get => this.name;
            set
            {
                if (value == " " || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public List<Topping> Toppings { get; set; }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);

            if (this.Toppings.Count > MaxToppingsCount)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public double GetTotalCalories()
        {
            double totalCalories = 0;

            totalCalories += this.Dough.CalculateCalories();

            if (this.Toppings.Count > 0)
            {
                foreach (var topping in this.Toppings)
                {
                    totalCalories += topping.CalculateCalories();
                }

            }

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():F2} Calories.";
        }
    }
}
