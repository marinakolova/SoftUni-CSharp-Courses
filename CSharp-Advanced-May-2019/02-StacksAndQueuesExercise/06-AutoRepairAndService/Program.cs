using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var queue = new Queue<string>(vehicles);
            var served = new Stack<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "Service":
                        if (queue.Count > 0)
                        {
                            served.Push(queue.Dequeue());
                            Console.WriteLine($"Vehicle {served.Peek()} got served.");
                        }
                        break;

                    case "History":
                        Console.WriteLine(string.Join(", ", served));
                        break;

                    default:
                        var carInfo = command.Split("-").ToArray();
                        var model = carInfo[1];
                        if (queue.Contains(model))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }
                        break;
                }
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", queue)}");
            }
            Console.WriteLine($"Served vehicles: {string.Join(", ", served)}");
        }
    }
}
