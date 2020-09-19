using System;

namespace _01_SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintTheSignOfAnInteger(num);
        }

        private static void PrintTheSignOfAnInteger(int n)
        {
            if (n < 0)
            {
                Console.WriteLine($"The number {n} is negative.");
            }

            else if (n == 0)
            {
                Console.WriteLine($"The number {n} is zero.");
            }

            else if (n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }
        }
    }
}
