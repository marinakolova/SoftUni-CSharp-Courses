using System;

namespace _09_SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(2 * i - 1);
                sum += 2 * i - 1;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
