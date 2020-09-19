using System;
using System.Collections.Generic;

namespace _01_CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var counts = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (currChar != ' ')
                {                    
                    if (counts.ContainsKey(currChar))
                    {
                        counts[currChar]++;
                    }
                    else
                    {
                        counts.Add(currChar, 1);
                    }
                }
            }

            foreach (var charr in counts)
            {
                Console.WriteLine($"{charr.Key} -> {charr.Value}");
            }
        }
    }
}
