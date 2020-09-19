using System;
using System.IO;

namespace _5_SliceAFile
{
    class SliceAFile
    {
        static void Main(string[] args)
        {
            using (var inputFile = new FileStream(Path.Combine("Resources", "sliceMe.txt"), FileMode.Open))
            {
                long size = inputFile.Length;
                int partSize = (int)Math.Ceiling((double)size / 4);
                byte[] buffer = new byte[partSize];

                for (int i = 1; i <= 4; i++)
                {
                    using (var outputFile = new FileStream($"Part-{i}.txt", FileMode.Create))
                    {
                        int readedBytes = inputFile.Read(buffer, 0, partSize);
                        outputFile.Write(buffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}
