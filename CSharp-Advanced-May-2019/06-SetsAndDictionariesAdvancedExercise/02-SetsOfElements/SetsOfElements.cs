using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] paramethers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = paramethers[0];
            int m = paramethers[1];

            var firstSet = new List<string>();
            var secondSet = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var num = Console.ReadLine();

                if (!firstSet.Contains(num))
                {
                    firstSet.Add(num);
                }
            }

            for (int i = 0; i < m; i++)
            {
                var num = Console.ReadLine();

                if (!secondSet.Contains(num))
                {
                    secondSet.Add(num);
                }
            }

            for (int i = 0; i < firstSet.Count; i++)
            {
                var num = firstSet[i];

                if (!secondSet.Contains(num))
                {
                    firstSet.Remove(num);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
