using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            foreach (var order in orders)
            {
                queue.Enqueue(order);
            }

            Console.WriteLine(queue.Max());

            while (food > 0)
            {
                if (queue.Count > 0 && queue.Peek() <= food)
                {
                    food -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
