using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstTimeline = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var secondTimeline = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var table = new int[firstTimeline.Length + 1, secondTimeline.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (firstTimeline[r - 1] == secondTimeline[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r, c - 1], table[r - 1, c]);
                    }
                }
            }

            var row = firstTimeline.Length;
            var col = secondTimeline.Length;

            var lcs = new Stack<int>();

            while (row > 0 && col > 0)
            {
                if (firstTimeline[row - 1] == secondTimeline[col - 1])
                {
                    lcs.Push(firstTimeline[row - 1]);
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

            Console.WriteLine(string.Join(" ", lcs));
            Console.WriteLine(lcs.Count);
        }
    }
}
