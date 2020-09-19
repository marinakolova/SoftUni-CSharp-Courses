using System;
using System.IO;

namespace _4_CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputFilePath = Path.Combine("Resources", "copyMe.png");
            string outputFilePath = "pastedFile.png";
            int bufferSize = 1024 * 1024;

            using (FileStream fileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                FileStream fs = new FileStream(inputFilePath, FileMode.Open, FileAccess.ReadWrite);
                fileStream.SetLength(fs.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];

                while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                }
            }
        }
    }
}
