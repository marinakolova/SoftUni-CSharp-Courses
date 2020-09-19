using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nums[0];
            int s = nums[1];
            int x = nums[2];

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            foreach (var num in numbers)
            {
                queue.Enqueue(num);
            }

            for (int i = 0; i < s; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
