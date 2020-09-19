using System;

namespace _10_TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                bool isTopNumber = CheckIfTop(i);
                if (isTopNumber)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool CheckIfTop(int num)
        {
            bool sumOfDigDivBy8 = CheckIfSumOfDigDivBy8(num);
            bool holdsAnOddDig = CheckIfItHoldAnOddDig(num);

            if (sumOfDigDivBy8 && holdsAnOddDig)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIfSumOfDigDivBy8(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                int lasDigit = num % 10;
                sum += lasDigit;
                num /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIfItHoldAnOddDig(int num)
        {
            int oddDigits = 0;

            while (num > 0)
            {
                int lasDigit = num % 10;
                if (lasDigit % 2 != 0)
                {
                    oddDigits++;
                }
                num /= 10;
            }

            if (oddDigits > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
