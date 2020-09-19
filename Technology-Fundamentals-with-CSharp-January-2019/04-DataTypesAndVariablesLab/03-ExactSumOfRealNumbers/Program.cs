using System;

namespace _03_ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal num = 0;
            decimal sum = 0;

            for (int i = 1; i <= n; i++)
            {
                num = decimal.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
