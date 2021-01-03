using System;

namespace _07_MinimumEditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var replaceCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r * deleteCost;
            }

            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c * insertCost;
            }

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    var cost = str1[r - 1] == str2[c - 1] ? 0 : replaceCost;

                    var delete = table[r - 1, c] + deleteCost;
                    var replace = table[r - 1, c - 1] + cost;
                    var insert = table[r, c - 1] + insertCost;

                    table[r, c] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            Console.WriteLine($"Minimum edit distance: {table[str1.Length, str2.Length]}");
        }
    }
}
