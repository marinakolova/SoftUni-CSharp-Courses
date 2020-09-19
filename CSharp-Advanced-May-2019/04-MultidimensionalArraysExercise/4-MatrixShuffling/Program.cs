using System;
using System.Linq;

namespace _4_MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (partsOfCommand[0] != "swap"
                    || partsOfCommand.Length != 5
                    || int.Parse(partsOfCommand[1]) < 0
                    || int.Parse(partsOfCommand[1]) > matrix.GetLength(0) - 1
                    || int.Parse(partsOfCommand[2]) < 0
                    || int.Parse(partsOfCommand[2]) > matrix.GetLength(1) - 1
                    || int.Parse(partsOfCommand[3]) < 0
                    || int.Parse(partsOfCommand[3]) > matrix.GetLength(0) - 1
                    || int.Parse(partsOfCommand[4]) < 0
                    || int.Parse(partsOfCommand[4]) > matrix.GetLength(1) - 1)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(partsOfCommand[1]);
                int col1 = int.Parse(partsOfCommand[2]);
                int row2 = int.Parse(partsOfCommand[3]);
                int col2 = int.Parse(partsOfCommand[4]);

                string prevState = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = prevState;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
