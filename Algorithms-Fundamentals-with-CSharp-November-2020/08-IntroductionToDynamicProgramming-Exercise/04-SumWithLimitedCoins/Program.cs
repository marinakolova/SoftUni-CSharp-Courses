using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_SumWithLimitedCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());            

            var count = GetCount(numbers, target);
            Console.WriteLine(count);

            // var sums = CalcSums(numbers);
            // Console.WriteLine(sums[target]);
        }

        private static int GetCount(int[] numbers, int target)
        {
            var sums = new HashSet<int> { 0 };
            var count = 0;

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = number + sum;
                    newSums.Add(newSum);

                    if (newSum == target)
                    {
                        count += 1;
                    }
                }

                sums.UnionWith(newSums);
            }

            return count;
        }

        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 1 } };

            foreach (var number in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, 1);
                    }
                    else
                    {
                        result[newSum] += 1;
                    }
                }
            }

            return result;
        }
    }
}
