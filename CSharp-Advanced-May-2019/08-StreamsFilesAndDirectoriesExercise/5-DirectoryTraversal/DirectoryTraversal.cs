using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5_DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string[] fileArray = Directory.GetFiles(".", "*.*");

            var dirInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = directoryInfo.GetFiles();

            foreach (var currentFile in allFiles)
            {
                double size = currentFile.Length / 1024d;
                string fileName = currentFile.Name;
                string extension = currentFile.Extension;

                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }

                dirInfo[extension].Add(fileName, size);                
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + @"/report.txt";

            foreach (var (extension, value) in dirInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                File.AppendAllText(path, extension + Environment.NewLine);

                foreach (var (fileName, size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"--{fileName} - {Math.Round(size, 3)}kb" + Environment.NewLine);
                }
            }          
        }
    }
}
