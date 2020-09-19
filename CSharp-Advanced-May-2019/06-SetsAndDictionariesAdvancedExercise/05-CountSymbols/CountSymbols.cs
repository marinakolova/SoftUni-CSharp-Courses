using System;
using System.Collections.Generic;

namespace _05_CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();

            var counter = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!counter.ContainsKey(text[i]))
                {
                    counter.Add(text[i], 0);
                }
                counter[text[i]]++;
            }

            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
