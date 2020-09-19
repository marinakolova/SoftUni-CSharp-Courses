using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> petrolPumps = new Queue<int[]>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int[] petrolPump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                petrolPumps.Enqueue(petrolPump);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var petrolPump in petrolPumps)
                {
                    int petrolAmount = petrolPump[0];
                    int distance = petrolPump[1];

                    totalFuel += petrolAmount - distance;

                    if (totalFuel < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
