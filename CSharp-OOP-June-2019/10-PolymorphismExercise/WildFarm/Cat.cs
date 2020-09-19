using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const string sound = "Meow";
        private List<string> food = new List<string> { "Vegetable", "Meat" };
        private const double weightIncrease = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
                Console.WriteLine($"Cat does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Cat [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
