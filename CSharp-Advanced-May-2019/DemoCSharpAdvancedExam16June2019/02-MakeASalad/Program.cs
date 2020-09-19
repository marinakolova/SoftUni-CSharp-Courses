using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegetables = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var calories = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var dict = new Dictionary<string, int>
            {
                { "tomato", 80 },
                { "carrot", 136 },
                { "lettuce", 109 },
                { "potato", 215 }
            };

            var saladsToMake = new Stack<int>();

            foreach (var salad in calories)
            {
                saladsToMake.Push(salad);
            }

            var vegetablesToTake = new Queue<string>();

            foreach (var veg in vegetables)
            {
                vegetablesToTake.Enqueue(veg);
            }

            var finishedSalads = new List<int>();

            while (saladsToMake.Count > 0 && vegetablesToTake.Count > 0)
            {
                var neededSalad = saladsToMake.Peek();

                while (neededSalad > 0 && vegetablesToTake.Count > 0)
                {
                    var vegetable = vegetablesToTake.Dequeue();

                    if (dict.ContainsKey(vegetable))
                    {
                        neededSalad -= dict[vegetable];
                    }
                }
                if (neededSalad < saladsToMake.Peek())
                {
                    finishedSalads.Add(saladsToMake.Pop());
                }
            }

            if (finishedSalads.Count > 0)
            {
                Console.WriteLine(string.Join(" ", finishedSalads));
            }
           
            if (vegetablesToTake.Count > 0)
            {
                Console.WriteLine(string.Join(" ", vegetablesToTake));
            }
            else if (saladsToMake.Count > 0)
            {
                Console.WriteLine(string.Join(" ", saladsToMake));
            }
        }
    }
}
