using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public abstract void ProduceSound();

        public abstract void Eat(string foodType, int quantity);
    }
}
