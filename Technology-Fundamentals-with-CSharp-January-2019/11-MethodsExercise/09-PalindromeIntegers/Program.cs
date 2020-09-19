using System;

namespace _09_PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                int number = int.Parse(input);
                bool isPalindrome = CheckIfPalindrome(number);
                Console.WriteLine(isPalindrome.ToString().ToLower());

                input = Console.ReadLine();
            }
        }

        private static bool CheckIfPalindrome(int number)
        {
            string num = number.ToString();
            string numReversed = Reverse(num);

            if (num == numReversed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}
