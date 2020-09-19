using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var collection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", collection.Where(x => x % n != 0)));
        }
    }
}
