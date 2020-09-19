using System;
using System.Numerics;

namespace _02_FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();

                BigInteger leftNum = BigInteger.Parse(input[0]);
                BigInteger rightNum = BigInteger.Parse(input[1]);

                BigInteger biggerNum = 0;

                if (leftNum >= rightNum)
                {
                    biggerNum = leftNum;
                }

                else if (rightNum > leftNum)
                {
                    biggerNum = rightNum;
                }

                BigInteger sumOfDigits = 0;

                while (BigInteger.Abs(biggerNum) > 0)
                {
                    BigInteger lastDigit = biggerNum % 10;
                    sumOfDigits += lastDigit;
                    biggerNum = biggerNum / 10;
                }

                Console.WriteLine(BigInteger.Abs(sumOfDigits));

            }
        }
    }
}
