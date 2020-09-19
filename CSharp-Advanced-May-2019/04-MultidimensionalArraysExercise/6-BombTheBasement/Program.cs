using System;
using System.Linq;

namespace _6_BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] basement = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[1]; j++)
                {
                    basement[i, j] = 0;
                }
            }

            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombRow = coordinates[0];
            int bombCol = coordinates[1];
            int radius = coordinates[2];

            int bombedFirstRowLength = radius + 1 + radius;
            int bombedRowsCount = radius + 1 + radius;

            for (int i = 0; i < bombedRowsCount; i++)
            {
                for (int j = bombCol - radius; j <= bombCol + radius; j++)
                {
                    if (i >= 0 && i < basement.GetLength(0)
                        && j >= 0 && j < basement.GetLength(1))
                    {
                        basement[i, j] = 1;
                    }
                }

                if (i == 0 || i % 2 == 0)
                {
                    radius -= 1;
                }
            }

            for (int i = 0; i < basement.GetLength(0); i++)
            {
                for (int j = 0; j < basement.GetLength(1); j++)
                {
                    Console.Write(basement[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
