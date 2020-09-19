using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3_WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            var words = new List<string>();

            using (var reader = new StreamReader(Path.Combine("Resources", "words.txt")))
            {
                string word = reader.ReadLine();

                while (word != null)
                {
                    words.Add(word);
                    word = reader.ReadLine();
                }                    
            }

            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                using (var reader = new StreamReader(Path.Combine("Resources", "text.txt")))
                {
                    int count = Regex.Matches(reader.ReadToEnd().ToString().ToLower(), $"[^a-zA-Z0-9]{word}[^a-zA-Z0-9]").Count;

                    dict.Add(word, count);
                }
            }

            using (var writer = new StreamWriter("actualResult.txt"))
            {
                foreach (var word in dict.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
