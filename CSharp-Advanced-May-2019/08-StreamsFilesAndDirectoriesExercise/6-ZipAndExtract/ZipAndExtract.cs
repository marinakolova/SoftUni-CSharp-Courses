using System;
using System.IO;
using System.IO.Compression;

namespace _6_ZipAndExtract
{
    class ZipAndExtract
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(Path.Combine(".", "Resources"), "myZip.zip");

            ZipFile.ExtractToDirectory("myZip.zip", ".");
        }
    }
}
