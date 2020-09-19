using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var cups = new Queue<int>();
            var bottles = new Stack<int>();

            foreach (var item in cupsInput)
            {
                cups.Enqueue(item);
            }

            foreach (var item in bottlesInput)
            {
                bottles.Push(item);
            }

            var wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                var currCup = cups.Dequeue();

                while (currCup > 0)
                {
                    currCup -= bottles.Pop();
                }

                if (currCup < 0)
                {
                    wastedWater += Math.Abs(currCup);
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
