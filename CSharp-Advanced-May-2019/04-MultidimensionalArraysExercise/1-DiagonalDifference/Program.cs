using System;
using System.Linq;

namespace _1_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < size; i++)
            {
                primarySum += matrix[i, i];
                secondarySum += matrix[i, size - 1 - i];
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
