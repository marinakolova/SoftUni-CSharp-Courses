using System;

namespace _02_SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while (num > 0)
            {
                int lastDigit = num % 10;
                sum += lastDigit;
                num = num / 10;
            }

            Console.WriteLine(sum);
        }
    }
}
