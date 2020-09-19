using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rackCapacity = int.Parse(Console.ReadLine());

            var box = new Stack<int>();
            foreach (var value in clothes)
            {
                box.Push(value);
            }

            var racksCount = 1;
            var currCapacity = rackCapacity;

            for (int i = 0; i < clothes.Length; i++)
            {
                if (box.Peek() <= currCapacity)
                {
                    currCapacity -= box.Pop();
                }
                else
                {
                    racksCount += 1;
                    currCapacity = rackCapacity;
                    currCapacity -= box.Pop();
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
