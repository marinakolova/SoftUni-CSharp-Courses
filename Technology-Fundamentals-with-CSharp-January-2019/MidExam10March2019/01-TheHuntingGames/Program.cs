using System;

namespace _01_TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayPerPerson = double.Parse(Console.ReadLine());
            double foodPerDayPerPerson = double.Parse(Console.ReadLine());

            double food = foodPerDayPerPerson * players * days;
            double water = waterPerDayPerPerson * players * days;

            double currFood = food;
            double currWater = water;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                currFood = food;
                currWater = water;

                groupEnergy -= energyLoss;

                if (groupEnergy <= 0)
                {
                    break;
                }

                if (i % 2 == 0)
                {
                    groupEnergy += 0.05 * groupEnergy;
                    water -= 0.3 * water;
                }

                if (i % 3 == 0)
                {
                    food -= food / players;
                    groupEnergy += 0.10 * groupEnergy;
                }
            }

            if (groupEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {currFood:F2} food and {currWater:F2} water.");
            }
        }
    }
}
