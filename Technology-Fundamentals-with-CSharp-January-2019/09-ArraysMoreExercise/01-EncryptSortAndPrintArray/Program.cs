using System;
using System.Linq;

namespace _01_EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStrings = int.Parse(Console.ReadLine());

            int[] numbers = new int[numOfStrings];
            int numOfString = -1;

            for (int i = 0; i < numOfStrings; i++)
            {
                string input = Console.ReadLine();
                numOfString++;

                int number = 0;

                char[] letters = input.ToCharArray();

                for (int j = 0; j < letters.Length; j++)
                {
                    if (letters[j] == 65
                        || letters[j] == 97
                        || letters[j] == 69
                        || letters[j] == 101
                        || letters[j] == 73
                        || letters[j] == 105
                        || letters[j] == 79
                        || letters[j] == 111
                        || letters[j] == 85
                        || letters[j] == 117)
                    {
                        number += letters[j] * letters.Length;
                    }
                    else
                    {
                        number += letters[j] / letters.Length;
                    }
                }

                numbers[numOfString] = number;
            }

            int[] numbersToPrint = (from element in numbers orderby element ascending select element)
                   .ToArray();

            foreach (var item in numbersToPrint)
            {
                Console.WriteLine(item);
            }
        }
    }
}
