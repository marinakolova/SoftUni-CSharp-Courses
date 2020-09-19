using System;
using System.Linq;

namespace _8_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] values = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] rows = new int[coordinates.Length];
            int[] cols = new int[coordinates.Length];

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] splitedCoordinates = coordinates[i].Split(",").Select(int.Parse).ToArray();
                rows[i] = splitedCoordinates[0];
                cols[i] = splitedCoordinates[1];
            }

            for (int i = 0; i < rows.Length; i++)
            {
                int bombRow = rows[i];
                int bombCol = cols[i];
                int bombValue = matrix[bombRow, bombCol];

                if (bombValue > 0)
                {
                    matrix[bombRow, bombCol] = 0;

                    if (IsValidCell(matrix, bombRow - 1, bombCol - 1)
                        && IsAlive(matrix, bombRow - 1, bombCol - 1))
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombValue;
                    }

                    if (IsValidCell(matrix, bombRow - 1, bombCol)
                        && IsAlive(matrix, bombRow - 1, bombCol))
                    {
                        matrix[bombRow - 1, bombCol] -= bombValue;
                    }

                    if (IsValidCell(matrix, bombRow - 1, bombCol + 1)
                        && IsAlive(matrix, bombRow - 1, bombCol + 1))
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombValue;
                    }

                    if (IsValidCell(matrix, bombRow, bombCol - 1)
                        && IsAlive(matrix, bombRow, bombCol - 1))
                    {
                        matrix[bombRow, bombCol - 1] -= bombValue;
                    }

                    if (IsValidCell(matrix, bombRow, bombCol + 1)
                        && IsAlive(matrix, bombRow, bombCol + 1))
                    {
                        matrix[bombRow, bombCol + 1] -= bombValue;
                    }

                    if (IsValidCell(matrix, bombRow + 1, bombCol - 1)
                        && IsAlive(matrix, bombRow + 1, bombCol - 1))
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombValue;
                    }

                    if (IsValidCell(matrix, bombRow + 1, bombCol)
                        && IsAlive(matrix, bombRow + 1, bombCol))
                    {
                        matrix[bombRow + 1, bombCol] -= bombValue;
                    }

                    if (IsValidCell(matrix, bombRow + 1, bombCol + 1)
                        && IsAlive(matrix, bombRow + 1, bombCol + 1))
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombValue;
                    }
                }
            }

            int aliveCells = 0;
            int sumOfCells = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumOfCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsAlive(int[,] matrix, int checkedRow, int checkedCol)
        {
            return matrix[checkedRow, checkedCol] > 0;
        }

        private static bool IsValidCell(int[,] matrix, int checkedRow, int checkedCol)
        {
            return checkedRow >= 0 && checkedRow < matrix.GetLength(0)
                && checkedCol >= 0 && checkedCol < matrix.GetLength(1);
        }
    }
}
