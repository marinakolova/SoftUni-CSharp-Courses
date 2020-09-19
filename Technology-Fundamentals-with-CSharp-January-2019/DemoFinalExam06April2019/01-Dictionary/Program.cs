using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var definitions = Console.ReadLine().Split(" | ").ToList();
            var theDictionary = new Dictionary<string, List<string>>();

            foreach (var pair in definitions)
            {
                var partsOfPair = pair.Split(": ");
                var word = partsOfPair[0];
                var definition = partsOfPair[1];

                if (!theDictionary.ContainsKey(word))
                {
                    theDictionary.Add(word, new List<string>());
                }
                theDictionary[word].Add(definition);
            }

            var wordsToPrint = Console.ReadLine().Split(" | ").ToList();

            foreach (var word in wordsToPrint)
            {
                if (theDictionary.ContainsKey(word))
                {
                    Console.WriteLine($"{word}");

                    foreach (var definition in theDictionary[word].OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }

            var command = Console.ReadLine();

            if (command == "List")
            {
                Console.WriteLine(string.Join(" ", theDictionary.Keys.OrderBy(x => x)));
            }
        }
    }
}
