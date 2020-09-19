using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const string sound = "Cluck";
        private List<string> food = new List<string> { "Vegetable", "Fruit", "Meat", "Seeds" };
        private const double weightIncrease = 0.35;

        public Hen(string name, double weight, double wingSize)
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
                Console.WriteLine($"Hen does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Hen [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
