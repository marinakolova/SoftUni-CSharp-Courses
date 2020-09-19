using System;
using System.Linq;

namespace _2_SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                char[] chars = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }

            int squaresMatrixes = 0;

            for (int row = 0; row < dimensions[0] - 1; row++)
            {
                for (int col = 0; col < dimensions[1] - 1; col++)
                {
                    char currChar = matrix[row, col];

                    if (matrix[row, col + 1] == currChar
                        && matrix[row + 1, col] == currChar
                        && matrix[row + 1, col + 1] == currChar)
                    {
                        squaresMatrixes++;
                    }
                }
            }

            Console.WriteLine(squaresMatrixes);
        }
    }
}
