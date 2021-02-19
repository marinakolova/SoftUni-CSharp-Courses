using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_LongestZigzagSubsequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var dp = new int[2, numbers.Length];
            dp[0, 0] = 1;
            dp[1, 0] = 1;

            var parent = new int[2, numbers.Length];
            parent[0, 0] = -1;
            parent[1, 0] = -1;

            var bestSize = 0;
            var lastRowInx = 0;
            var lastColInx = 0;

            for (int curr = 0; curr < numbers.Length; curr++)
            {
                var currNumber = numbers[curr];

                for (int prev = curr - 1; prev >= 0; prev--)
                {
                    var prevNumber = numbers[prev];

                    if (currNumber > prevNumber &&
                        dp[1, prev] + 1 >= dp[0, curr]) // >= -> because we  take left
                    {
                        dp[0, curr] = dp[1, prev] + 1;
                        parent[0, curr] = prev;
                    }

                    if (currNumber < prevNumber &&
                        dp[0, prev] + 1 >= dp[1, curr]) // >= -> because we  take left
                    {
                        dp[1, curr] = dp[0, prev] + 1;
                        parent[1, curr] = prev;
                    }
                }

                if (dp[0, curr] > bestSize)
                {
                    bestSize = dp[0, curr];

                    lastRowInx = 0;
                    lastColInx = curr;
                }

                if (dp[1, curr] > bestSize)
                {
                    bestSize = dp[1, curr];

                    lastRowInx = 1;
                    lastColInx = curr;
                }
            }

            var zigZagSeq = new Stack<int>();

            while (lastColInx != -1)
            {
                zigZagSeq.Push(numbers[lastColInx]);

                lastColInx = parent[lastRowInx, lastColInx];

                if (lastRowInx == 0)
                {
                    lastRowInx = 1;
                }
                else
                {
                    lastRowInx = 0;
                }
            }

            Console.WriteLine(string.Join(" ", zigZagSeq));
        }
    }
}
