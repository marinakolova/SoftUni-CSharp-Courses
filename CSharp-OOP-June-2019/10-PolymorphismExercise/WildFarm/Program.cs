using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var foodType = foodInfo[0];
                var quantity = int.Parse(foodInfo[1]);

                if (animalInfo[0] == "Owl")
                {
                    var name = animalInfo[1];
                    var weight = double.Parse(animalInfo[2]);
                    var wingSize = double.Parse(animalInfo[3]);

                    var animal = new Owl(name, weight, wingSize);
                    animal.ProduceSound();
                    animal.Eat(foodType, quantity);

                    animals.Add(animal);
                }

                else if (animalInfo[0] == "Hen")
                {
                    var name = animalInfo[1];
                    var weight = double.Parse(animalInfo[2]);
                    var wingSize = double.Parse(animalInfo[3]);

                    var animal = new Hen(name, weight, wingSize);
                    animal.ProduceSound();
                    animal.Eat(foodType, quantity);

                    animals.Add(animal);
                }

                else if (animalInfo[0] == "Mouse")
                {
                    var name = animalInfo[1];
                    var weight = double.Parse(animalInfo[2]);
                    var livingRegion = animalInfo[3];

                    var animal = new Mouse(name, weight, livingRegion);
                    animal.ProduceSound();
                    animal.Eat(foodType, quantity);

                    animals.Add(animal);
                }

                else if (animalInfo[0] == "Dog")
                {
                    var name = animalInfo[1];
                    var weight = double.Parse(animalInfo[2]);
                    var livingRegion = animalInfo[3];

                    var animal = new Dog(name, weight, livingRegion);
                    animal.ProduceSound();
                    animal.Eat(foodType, quantity);

                    animals.Add(animal);
                }

                else if (animalInfo[0] == "Cat")
                {
                    var name = animalInfo[1];
                    var weight = double.Parse(animalInfo[2]);
                    var livingRegion = animalInfo[3];
                    var breed = animalInfo[4];

                    var animal = new Cat(name, weight, livingRegion, breed);
                    animal.ProduceSound();
                    animal.Eat(foodType, quantity);

                    animals.Add(animal);
                }

                else if (animalInfo[0] == "Tiger")
                {
                    var name = animalInfo[1];
                    var weight = double.Parse(animalInfo[2]);
                    var livingRegion = animalInfo[3];
                    var breed = animalInfo[4];

                    var animal = new Tiger(name, weight, livingRegion, breed);
                    animal.ProduceSound();
                    animal.Eat(foodType, quantity);

                    animals.Add(animal);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
