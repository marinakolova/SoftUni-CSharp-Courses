using System;

namespace _10_MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleOfEvenAndOdds(input);
            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int input)
        {
            int sumOfEvenDigits = GetSumOfEvenDigits(input);
            int sumOfOddDigits = GetSumOfOddDigits(input);
            return sumOfEvenDigits * sumOfOddDigits;
        }

        private static int GetSumOfEvenDigits(int input)
        {
            int sum = 0;

            for (int i = input; i > 0; i /= 10)
            {
                int digit = i % 10;

                if (digit % 2 == 0)
                {
                    sum += digit;
                }
            }

            return sum;
        }

        private static int GetSumOfOddDigits(int input)
        {
            int sum = 0;

            for (int i = input; i > 0; i /= 10)
            {
                int digit = i % 10;

                if (digit % 2 != 0)
                {
                    sum += digit;
                }
            }

            return sum;
        }
    }
}
