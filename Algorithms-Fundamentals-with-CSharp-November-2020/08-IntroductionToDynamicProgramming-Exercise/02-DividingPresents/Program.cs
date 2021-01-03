using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_DividingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sums = CalcSums(presents);

            var totalScore = presents.Sum();

            var bobScore = (int)Math.Ceiling(totalScore / 2.00);
            while (!sums.ContainsKey(bobScore))
            {
                bobScore += 1;
            }

            var alanScore = totalScore - bobScore;
            var alanPresents = GetPresents(sums, alanScore);

            Console.WriteLine($"Difference: {bobScore - alanScore}");
            Console.WriteLine($"Alan:{alanScore} Bob:{bobScore}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static List<int> GetPresents(Dictionary<int, int> sums, int target)
        {
            var presents = new List<int>();

            while (target != 0)
            {
                var present = sums[target];
                presents.Add(present);
                target -= present;
            }

            return presents;
        }

        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 0 } };

            foreach (var number in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, number);
                    }
                }
            }

            return result;
        }
    }
}
