using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> printer = x => x.ForEach(y => Console.WriteLine($"Sir {y}"));

            printer(input);
        }
    }
}
