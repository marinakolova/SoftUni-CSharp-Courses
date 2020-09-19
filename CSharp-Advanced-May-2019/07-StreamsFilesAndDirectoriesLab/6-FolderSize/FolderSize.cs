using System;
using System.IO;

namespace _6_FolderSize
{
    class FolderSize
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Path.Combine("Resources", "TestFolder"));
            long sum = 0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            var sumInMB = (sum / 1024.0) / 1024.0;

            File.WriteAllText("result.txt", sumInMB.ToString());
        }
    }
}
