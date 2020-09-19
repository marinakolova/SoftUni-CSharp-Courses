using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03_TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Console.ReadLine().Split().Select(int.Parse).ToList();
            var lines = new List<string>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "find")
                {
                    break;
                }

                lines.Add(line);
            }

            foreach (var line in lines)
            {
                var currKey = new List<int>(key);
                var currLine = line;

                while (currKey.Count != currLine.Length)
                {
                    for (int i = 0; i < key.Count; i++)
                    {
                        if (currKey.Count != currLine.Length)
                        {
                            currKey.Add(key[i]);
                        }
                    }
                }

                StringBuilder decryptedMessage = new StringBuilder();

                for (int i = 0; i < currLine.Length; i++)
                {
                    var charToAdd = currLine[i] - currKey[i];

                    decryptedMessage.Append((char)charToAdd);
                }

                Match type = Regex.Match(decryptedMessage.ToString(), @"([&])([\S]+)([&])");
                Match coordinates = Regex.Match(decryptedMessage.ToString(), @"([<])([\S]+)([>])");

                Console.WriteLine($"Found {type.Groups[2].Value} at {coordinates.Groups[2].Value}");
            }
        }
    }
}
