using System;
using System.Linq;

namespace _2_SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] arr = new int[dimensions[0], dimensions[1]];
            int[] sum = new int[dimensions[1]];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = nums[j];
                    sum[j] += nums[j];
                }
            }

            foreach (var item in sum)
            {
                Console.WriteLine(item);
            }
        }
    }
}
