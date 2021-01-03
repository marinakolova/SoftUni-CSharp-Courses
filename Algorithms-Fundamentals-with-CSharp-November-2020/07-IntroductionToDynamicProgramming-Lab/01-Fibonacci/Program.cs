using System;
using System.Collections.Generic;

namespace _01_Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> memo;
        
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            memo = new Dictionary<int, long>();

            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if (n <= 2)
            {
                return 1;
            }

            var result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            memo[n] = result;

            return result;
        }
    }
}
