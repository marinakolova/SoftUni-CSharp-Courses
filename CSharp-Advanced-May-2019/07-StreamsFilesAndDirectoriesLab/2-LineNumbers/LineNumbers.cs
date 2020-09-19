using System;
using System.IO;

namespace _2_LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(Path.Combine("Resources", "Input.txt")))
            {
                int count = 1;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{count}. {line}");

                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
