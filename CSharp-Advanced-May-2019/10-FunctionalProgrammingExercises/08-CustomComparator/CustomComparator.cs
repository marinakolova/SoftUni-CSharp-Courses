using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Predicate<int> isEven = n => n % 2 == 0;

            var evenNums = new List<int>();
            var oddNums = new List<int>();

            foreach (var num in arr)
            {
                if (isEven(num))
                {
                    evenNums.Add(num);
                }
                else
                {
                    oddNums.Add(num);
                }
            }

            Console.WriteLine($"{string.Join(" ", evenNums.OrderBy(x => x))} {string.Join(" ", oddNums.OrderBy(x => x))}");
        }
    }
}
