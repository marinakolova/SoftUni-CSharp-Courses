using System;
using System.Collections.Generic;

namespace _05_PathsInLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            labyrinth = ReadLab();
            FindPaths(0, 0, 'S');
        }

        static char[,] labyrinth;
        static List<char> path = new List<char>();

        private static char[,] ReadLab()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowElements = Console.ReadLine();
                
                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = rowElements[col];
                }
            }

            return labyrinth;
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            if (direction != 'S')
            {
                path.Add(direction);
            }

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }

            if (path.Count > 0)
            {
                path.RemoveAt(path.Count - 1);
            }
        }

        private static bool IsInBounds(int row, int col)
        {
            if (row >= 0 && row < labyrinth.GetLength(0)
                && col >= 0 && col < labyrinth.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static bool IsVisited(int row, int col)
        {
            return labyrinth[row, col] == 'v';
        }

        private static bool IsFree(int row, int col)
        {
            return labyrinth[row, col] == '-';
        }

        private static void Mark(int row, int col)
        {
            labyrinth[row, col] = 'v';
        }

        private static void Unmark(int row, int col)
        {
            labyrinth[row, col] = '-';
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path));
        }
    }
}
