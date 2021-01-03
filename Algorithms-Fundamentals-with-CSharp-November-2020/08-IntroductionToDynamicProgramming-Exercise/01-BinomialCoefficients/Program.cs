using System;
using System.Collections.Generic;

namespace _01_BinomialCoefficients
{
    class Program
    {
        private static Dictionary<string, long> cache;
        
        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));
        }

        private static long GetBinom(int row, int col)
        {            
            var id = $"{row} {col}";

            if (cache.ContainsKey(id))
            {
                return cache[id];
            }

            if (col == 0 || col == row)
            {
                return 1;
            }

            var result = GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
            cache.Add(id, result);
            return result;
        }
    }
}
