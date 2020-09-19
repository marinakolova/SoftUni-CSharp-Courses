using System;
using System.IO;

namespace _4_MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            using (var readerOne = new StreamReader(Path.Combine("Resources", "FileOne.txt")))
            {
                using (var readerTwo = new StreamReader(Path.Combine("Resources", "FileTwo.txt")))
                {
                    using (var writer = new StreamWriter("Output.txt"))
                    {
                        var lineOne = readerOne.ReadLine();
                        var lineTwo = readerTwo.ReadLine();

                        while (lineOne != null || lineTwo != null)
                        {
                            writer.WriteLine(lineOne);
                            writer.WriteLine(lineTwo);

                            lineOne = readerOne.ReadLine();
                            lineTwo = readerTwo.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
