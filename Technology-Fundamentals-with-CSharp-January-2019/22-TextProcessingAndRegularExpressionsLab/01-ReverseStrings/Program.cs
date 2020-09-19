using System;
using System.Collections.Generic;

namespace _01_ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringsToReverse = new List<string>();
            var reversedStrings = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                stringsToReverse.Add(input);
            }

            for (int i = 0; i < stringsToReverse.Count; i++)
            {
                string normal = stringsToReverse[i];
                string reversed = "";

                for (int j = normal.Length - 1; j >= 0; j--)
                {
                    reversed += normal[j];
                }

                reversedStrings.Add(reversed);
            }

            for (int i = 0; i < reversedStrings.Count; i++)
            {
                Console.WriteLine($"{stringsToReverse[i]} = {reversedStrings[i]}");
            }
        }
    }
}
