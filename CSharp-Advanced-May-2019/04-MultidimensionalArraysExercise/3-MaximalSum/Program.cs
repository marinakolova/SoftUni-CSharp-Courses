using System;
using System.Linq;

namespace _3_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            int maxSum = int.MinValue;
            int selectedRow = -1;
            int selectedCol = -1;

            for (int row = 0; row < dimensions[0] - 2; row++)
            {
                for (int col = 0; col < dimensions[1] - 2; col++)
                {
                    int sum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row, col + 2]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1]
                        + matrix[row + 1, col + 2]
                        + matrix[row + 2, col]
                        + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        selectedCol = col;
                        selectedRow = row;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[selectedRow, selectedCol]} {matrix[selectedRow, selectedCol + 1]} {matrix[selectedRow, selectedCol + 2]}");
            Console.WriteLine($"{matrix[selectedRow + 1, selectedCol]} {matrix[selectedRow + 1, selectedCol + 1]} {matrix[selectedRow + 1, selectedCol + 2]}");
            Console.WriteLine($"{matrix[selectedRow + 2, selectedCol]} {matrix[selectedRow + 2, selectedCol + 1]} {matrix[selectedRow + 2, selectedCol + 2]}");
        }
    }
}
