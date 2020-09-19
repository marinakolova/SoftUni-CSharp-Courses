using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            List<string> shuffled = new List<string>();
            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                shuffled.Insert(rnd.Next(0, shuffled.Count + 1), input[i]);
            }

            foreach (var word in shuffled)
            {
                Console.WriteLine(word);
            }
        }
    }
}
