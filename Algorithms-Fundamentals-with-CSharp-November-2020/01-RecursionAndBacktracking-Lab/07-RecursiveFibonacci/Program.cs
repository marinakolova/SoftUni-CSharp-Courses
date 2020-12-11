using System;
using System.Collections.Generic;

namespace _07_RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var fibonacci = new List<int>();
            fibonacci.Add(0);
            fibonacci.Add(1);

            while (fibonacci.Count < n + 2)
            {
                var newFibonacci = fibonacci[^1] + fibonacci[^2];
                fibonacci.Add(newFibonacci);
            }

            Console.WriteLine(fibonacci[^1]);

            //Console.WriteLine(GetFibonacci(n));
        }

        private static int GetFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
