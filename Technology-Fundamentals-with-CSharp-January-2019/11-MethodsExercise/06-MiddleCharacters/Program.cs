using System;

namespace _06_MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintTheMiddleCharacter(input);
        }

        private static void PrintTheMiddleCharacter(string input)
        {
            char[] characters = input.ToCharArray();

            if (characters.Length % 2 == 0)
            {
                Console.Write(characters[characters.Length / 2 - 1]);
                Console.WriteLine(characters[characters.Length / 2]);
            }

            else
            {
                Console.WriteLine(characters[characters.Length / 2]);
            }
        }
    }
}
