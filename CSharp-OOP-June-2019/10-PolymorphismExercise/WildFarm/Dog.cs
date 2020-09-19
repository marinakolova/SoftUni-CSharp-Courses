using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const string sound = "Woof!";
        private List<string> food = new List<string> { "Meat" };
        private const double weightIncrease = 0.40;

        public Dog(string name, double weight, string livingRegion)
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
                Console.WriteLine($"Dog does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Dog [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
