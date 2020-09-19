using System;
using System.IO;

namespace _1_OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(Path.Combine("Resources", "Input.txt")))
            {
                int count = 0;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
