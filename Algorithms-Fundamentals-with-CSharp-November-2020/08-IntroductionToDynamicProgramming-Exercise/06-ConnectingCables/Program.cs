using System;
using System.Linq;

namespace _06_ConnectingCables
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var positions = new int[numbers.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = i + 1;
            }

            var table = new int[numbers.Length + 1, numbers.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (numbers[r - 1] == positions[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r, c - 1], table[r - 1, c]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {table[numbers.Length, numbers.Length]}");
        }
    }
}
