using System;

namespace _06_StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int originalNum = num;

            int lastDigit = 0;
            int factoriralSum = 0;

            while (num != 0)
            {
                lastDigit = num % 10;
                num = num / 10;

                int factorial = 1;

                for (int i = 1; i <= lastDigit; i++)
                {
                    factorial = factorial * i;
                }

                factoriralSum = factoriralSum + factorial;
            }

            if (factoriralSum == originalNum)
            {
                Console.WriteLine("yes");
            }

            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
