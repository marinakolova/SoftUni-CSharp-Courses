using System;

namespace _05_AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = GetTheSum(a, b);
            Subtract(sum, c);
        }

        private static int GetTheSum(int a, int b)
        {
            return a + b;
        }

        private static void Subtract(int sum, int c)
        {
            Console.WriteLine(sum - c);
        }
    }
}
