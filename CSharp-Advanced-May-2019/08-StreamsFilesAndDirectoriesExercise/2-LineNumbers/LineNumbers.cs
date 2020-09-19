using System;
using System.IO;

namespace _2_LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(Path.Combine("Resources", "text.txt")))
            {
                string line = reader.ReadLine();
                int count = 1;
                int lettersCount = 0;
                int punctMarksCount = 0;

                using (var writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsLetter(line[i]))
                            {
                                lettersCount++;
                            }
                            else if (char.IsPunctuation(line[i]))
                            {
                                punctMarksCount++;
                            }
                        }

                        writer.WriteLine($"Line {count}: {line} ({lettersCount})({punctMarksCount})");

                        line = reader.ReadLine();
                        count++;
                        lettersCount = 0;
                        punctMarksCount = 0;
                    }
                }
            }
        }
    }
}
