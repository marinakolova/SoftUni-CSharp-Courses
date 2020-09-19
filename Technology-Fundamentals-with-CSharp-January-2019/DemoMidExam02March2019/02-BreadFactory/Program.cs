using System;

namespace _02_BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = 100;
            int coins = 100;

            string[] events = Console.ReadLine().Split("|");

            for (int i = 0; i < events.Length; i++)
            {
                string[] currentEvent = events[i].Split("-");

                if (currentEvent[0] == "rest")
                {
                    int energyToGain = int.Parse(currentEvent[1]);

                    if (energy + energyToGain <= 100)
                    {
                        energy += energyToGain;
                        Console.WriteLine($"You gained {energyToGain} energy.");
                        Console.WriteLine($"Current energy: {energy}.");
                    }

                    else if (energy + energyToGain > 100)
                    {
                        int gainedEnergy = 100 - energy;
                        energy = 100;
                        Console.WriteLine($"You gained {gainedEnergy} energy.");
                        Console.WriteLine($"Current energy: {energy}.");
                    }
                }

                else if (currentEvent[0] == "order")
                {
                    energy -= 30;
                    int coinsToEarn = int.Parse(currentEvent[1]);

                    if (energy >= 0)
                    {
                        coins += coinsToEarn;
                        Console.WriteLine($"You earned {coinsToEarn} coins.");
                    }

                    else if (energy < 0)
                    {
                        energy += 80;
                        Console.WriteLine("You had to rest!");
                    }
                }

                else
                {
                    string ingredientToBuy = currentEvent[0];
                    int priceOfIngr = int.Parse(currentEvent[1]);

                    coins -= priceOfIngr;

                    if (coins > 0)
                    {
                        Console.WriteLine($"You bought {ingredientToBuy}.");
                    }

                    else if (coins <= 0)
                    {
                        Console.WriteLine($"Closed! Cannot afford {ingredientToBuy}.");
                        break;
                    }
                }
            }

            if (coins > 0)
            {
                Console.WriteLine($"Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
            }
        }
    }
}
