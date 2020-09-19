using System;

namespace _03_CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            PrintAllCharsBetween(start, end);
        }

        private static void PrintAllCharsBetween(char start, char end)
        {
            string charsToPrint = "";

            if ((int)start < (int)end)
            {
                for (int i = (int)start + 1; i < (int)end; i++)
                {
                    char nextChar = (char)i;
                    charsToPrint += nextChar;
                }
            }

            else if ((int)start > (int)end)
            {
                for (int i = (int)end + 1; i < (int)start; i++)
                {
                    char nextChar = (char)i;
                    charsToPrint += nextChar;
                }
            }

            char[] output = charsToPrint.ToCharArray();

            foreach (var character in output)
            {
                Console.Write(character + " ");
            }
            Console.WriteLine();
        }
    }
}
