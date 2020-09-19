using System;
using System.Collections.Generic;

namespace _10_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            bool isHitted = false;
            string hittedCarName = string.Empty;
            char hittedSymbol = '\0';
            int totalCars = 0;

            while (input != "END")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currGreenLight = greenLight;

                while (currGreenLight > 0 && queue.Count > 0)
                {
                    string carName = queue.Dequeue();
                    int carLength = carName.Length;

                    if (currGreenLight - carLength >= 0)
                    {
                        currGreenLight -= carLength;
                        totalCars++;
                    }
                    else
                    {
                        currGreenLight += freeWindow;

                        if (currGreenLight - carLength >= 0)
                        {
                            totalCars++;
                            break;
                        }
                        else
                        {
                            isHitted = true;
                            hittedCarName = carName;
                            hittedSymbol = carName[currGreenLight];
                            break;
                        }
                    }
                }

                if (isHitted)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }
    }
}
