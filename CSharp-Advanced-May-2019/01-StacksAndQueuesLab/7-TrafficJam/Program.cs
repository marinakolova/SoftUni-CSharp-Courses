using System;
using System.Collections.Generic;

namespace _7_TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int passedCars = 0;
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    for (int i = 1; i <= n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            passedCars++;
                        }
                    }
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
