using System;
using System.Linq;

namespace _04_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = input.Length / 4;

            int[] upperRow = new int[2 * k];
            int[] upperRowFirstHalf = new int[k];
            int[] upperRowSecondHalf = new int[k];
            int[] lowerRow = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                upperRowFirstHalf[i] = input[k - 1 - i];
            }

            for (int l = 0; l < k; l++)
            {
                upperRow[l] = upperRowFirstHalf[l];
            }

            for (int j = 0; j < k; j++)
            {
                upperRowSecondHalf[j] = input[3 * k - 1 + k - j];
            }

            for (int m = 0; m < k; m++)
            {
                upperRow[m + k] = upperRowSecondHalf[m];
            }

            for (int low = 0; low < 2 * k; low++)
            {
                lowerRow[low] = input[k + low]; 
            }

            int[] result = new int[2 * k];

            for (int res = 0; res < 2 * k; res++)
            {
                result[res] = upperRow[res] + lowerRow[res];
            }

            Console.WriteLine(String.Join(" ", result));
            
        }
    }
}
