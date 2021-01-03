using System;
using System.Linq;

namespace _02_Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rightSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var table = new int[leftSocks.Length + 1, rightSocks.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (leftSocks[r - 1] == rightSocks[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r, c - 1], table[r - 1, c]);
                    }
                }
            }

            var row = leftSocks.Length;
            var col = rightSocks.Length;

            var lcsCount = 0;

            while (row > 0 && col > 0)
            {
                if (leftSocks[row - 1] == rightSocks[col - 1])
                {
                    lcsCount += 1;
                    row -= 1;
                    col -= 1;
                }
                else if (table[row, col - 1] >= table[row - 1, col])
                {
                    col -= 1;
                }
                else
                {
                    row -= 1;
                }
            }

            Console.WriteLine(lcsCount);
        }
    }
}
