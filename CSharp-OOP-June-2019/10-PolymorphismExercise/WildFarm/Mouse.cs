using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const string sound = "Squeak";
        private List<string> food = new List<string> { "Vegetable", "Fruit" };
        private const double weightIncrease = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
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
                Console.WriteLine($"Mouse does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Mouse [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
