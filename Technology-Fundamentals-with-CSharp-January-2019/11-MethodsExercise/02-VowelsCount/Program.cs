using System;
using System.Linq;

namespace _02_VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            PrintTheCountOfTheVowels(input);
        }

        private static void PrintTheCountOfTheVowels(string input)
        {
            int vowels = 0;

            char[] letters = input.ToCharArray();

            foreach (var letter in letters)
            {
                if (letter == 97
                    || letter == 101
                    || letter == 105
                    || letter == 111
                    || letter == 117)
                {
                    vowels++;
                }
            }

            Console.WriteLine(vowels);
        }
    }
}
