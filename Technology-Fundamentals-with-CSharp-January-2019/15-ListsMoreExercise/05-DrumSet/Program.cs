using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initialDrumset = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> finalDrumset = new List<int>(initialDrumset);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Hit it again, Gabsy!")
                {
                    break;
                }

                int hitPower = int.Parse(command);

                for (int i = 0; i < finalDrumset.Count; i++)
                {
                    finalDrumset[i] -= hitPower;

                    if (finalDrumset[i] <= 0)
                    {
                        double price = initialDrumset[i] * 3;

                        if (savings >= price)
                        {
                            savings -= price;
                            finalDrumset[i] = initialDrumset[i];
                        }
                    }

                    if (finalDrumset[i] < 0)
                    {
                        finalDrumset[i] = 0;
                    }
                }
            }

            while (finalDrumset.Contains(0))
            {
                finalDrumset.Remove(0);
            }

            Console.WriteLine(string.Join(" ", finalDrumset));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
