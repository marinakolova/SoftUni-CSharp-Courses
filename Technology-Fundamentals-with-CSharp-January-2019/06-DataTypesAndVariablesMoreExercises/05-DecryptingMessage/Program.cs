using System;

namespace _05_DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string message = "";

            for (int i = 1; i <= n; i++)
            {
                char inputLetter = char.Parse(Console.ReadLine());
                int inputLetterIndex = (int)inputLetter;
                int decryptedLetterIndex = inputLetterIndex + key;
                char decryptedLetter = (char)decryptedLetterIndex;
                message += decryptedLetter;
            }

            Console.WriteLine(message);
        }
    }
}
