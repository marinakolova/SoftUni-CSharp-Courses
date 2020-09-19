using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dict = new Dictionary<double, int>();

            foreach (var num in input)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }
                dict[num]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
