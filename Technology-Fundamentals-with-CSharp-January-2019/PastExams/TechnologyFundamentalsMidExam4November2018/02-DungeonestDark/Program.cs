using System;
using System.Linq;

namespace _02_DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;
            string[] rooms = Console.ReadLine()
                .Split(' ', '|')
                .ToArray();

            string[] itemOrMonster = new string[rooms.Length / 2];
            int[] number = new int[rooms.Length / 2];

            int counter1 = 0;
            for (int i = 0; i < rooms.Length / 2; i++)
            {
                itemOrMonster[i] = rooms[counter1];
                counter1 += 2;
            }

            int counter2 = 1;
            for (int j = 0; j < rooms.Length / 2; j++)
            {
                number[j] = int.Parse(rooms[counter2]);
                counter2 += 2;
            }

            bool isAlive = true;
            for (int k = 0; k < rooms.Length / 2; k++)
            {
                if (itemOrMonster[k] == "potion")
                {
                    health += number[k];
                    int healedFor = number[k];
                    if (health > 100)
                    {
                        int remain = health - 100;
                        healedFor -= remain;
                        health = 100;
                    }

                    Console.WriteLine($"You healed for {healedFor} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }

                else if (itemOrMonster[k] == "chest")
                {
                    coins += number[k];
                    Console.WriteLine($"You found {number[k]} coins.");
                }

                else
                {
                    health -= number[k];

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {itemOrMonster[k]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {itemOrMonster[k]}.");
                        Console.WriteLine($"Best room: {k + 1}");
                        isAlive = false;
                        break;
                    }
                }
            }

            if (isAlive)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
