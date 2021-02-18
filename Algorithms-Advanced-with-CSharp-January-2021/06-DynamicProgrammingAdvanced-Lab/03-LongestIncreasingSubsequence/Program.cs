using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_LongestIncreasingSubsequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var len = new int[numbers.Length];
            var prev = new int[numbers.Length];
            
            Array.Fill(prev, -1);

            var bestLen = 0;
            var lastIdx = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                var currentBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = numbers[j];

                    if (prevNumber < currentNumber &&
                        len[j] + 1 >= currentBestSeq)
                    {
                        currentBestSeq = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currentBestSeq > bestLen)
                {
                    bestLen = currentBestSeq;
                    lastIdx = i;
                }

                len[i] = currentBestSeq;
            }

            var lis = new Stack<int>();

            while (lastIdx != -1)
            {
                lis.Push(numbers[lastIdx]);
                lastIdx = prev[lastIdx];
            }

            Console.WriteLine(string.Join(" ", lis));
        }
    }
}
