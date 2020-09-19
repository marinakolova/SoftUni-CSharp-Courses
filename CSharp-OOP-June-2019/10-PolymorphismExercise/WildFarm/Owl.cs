using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const string sound = "Hoot Hoot";
        private List<string> food = new List<string> { "Meat" };
        private const double weightIncrease = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine(sound);
        }

        public override void Eat(string foodType, int quantity)
        {
            if (food.Contains(foodType))
            {
                this.Weight += weightIncrease * quantity;
                this.FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"Owl does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Owl [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
