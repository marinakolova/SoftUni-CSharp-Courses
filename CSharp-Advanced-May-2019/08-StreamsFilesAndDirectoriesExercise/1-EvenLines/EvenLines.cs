using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1_EvenLines
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(Path.Combine("Resources", "text.txt")))
            {
                string line = reader.ReadLine();
                int count = 0;

                while (line != null)
                {
                    if (count == 0 || count % 2 == 0)
                    {
                        var words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Replace('-', '@'))
                            .Select(x => x.Replace(',', '@'))
                            .Select(x => x.Replace('.', '@'))
                            .Select(x => x.Replace('!', '@'))
                            .Select(x => x.Replace('?', '@'))
                            .ToList();

                        words.Reverse();

                        Console.WriteLine(string.Join(" ", words));
                    }

                    line = reader.ReadLine();
                    count++;
                }
            }
        }
    }
}
