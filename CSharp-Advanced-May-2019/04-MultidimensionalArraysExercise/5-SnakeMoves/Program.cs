using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[] snake = Console.ReadLine().ToCharArray();

            int neededChars = dimensions[0] * dimensions[1];
            Queue<char> filling = new Queue<char>();

            while (neededChars > 0)
            {
                for (int i = 0; i < snake.Length; i++)
                {
                    filling.Enqueue(snake[i]);
                }

                neededChars -= snake.Length;
            }

            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = filling.Dequeue();
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
