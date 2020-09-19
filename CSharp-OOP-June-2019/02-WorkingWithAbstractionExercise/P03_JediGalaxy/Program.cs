using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int row = dimensions[0];
            int col = dimensions[1];

            var matrix = new int[row][];

            int value = 0;

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[col];

                for (int j = 0; j < col; j++)
                {
                    matrix[i][j] = value;
                    value++;
                }
            }

            string command = Console.ReadLine();

            long sum = 0;

            while (command != "Let the Force be with you")
            {
                var ivoPossition = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var ivoRow = ivoPossition[0];
                var ivoCol = ivoPossition[1];

                var evilPosition = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evilRow = evilPosition[0];
                var evilCol = evilPosition[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow < row && evilCol < col)
                    {
                        matrix[evilRow][evilCol] = 0;
                    }

                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0 && ivoCol < col)
                {
                    if (ivoRow < row && ivoCol >= 0)
                    {
                        sum += matrix[ivoRow][ivoCol];
                    }

                    ivoRow--;
                    ivoCol++;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}
