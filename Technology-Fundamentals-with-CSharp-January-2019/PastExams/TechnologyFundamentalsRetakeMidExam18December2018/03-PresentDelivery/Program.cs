using System;
using System.Linq;

namespace _03_PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            int santasPosition = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Merry Xmas!")
                {
                    break;
                }

                string[] partsOfCommand = command.Split();
                int jumpLength = int.Parse(partsOfCommand[1]);
                
                while (santasPosition + jumpLength > houses.Length - 1)
                {
                    int stepsMadeTillEnd = houses.Length - 1 - santasPosition;
                    santasPosition = 0;
                    jumpLength -= stepsMadeTillEnd + 1;
                }

                if (santasPosition + jumpLength <= houses.Length - 1)
                {
                    santasPosition += jumpLength;

                    if (houses[santasPosition] == 0)
                    {
                        Console.WriteLine($"House {santasPosition} will have a Merry Christmas.");
                    }
                    else
                    {
                        houses[santasPosition] -= 2;
                    }
                }
            }

            Console.WriteLine($"Santa's last position was {santasPosition}.");

            int failedHousesCount = 0;

            foreach (var house in houses)
            {
                if (house != 0)
                {
                    failedHousesCount++;
                }
            }

            if (failedHousesCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {failedHousesCount} houses.");
            }
        }
    }
}
