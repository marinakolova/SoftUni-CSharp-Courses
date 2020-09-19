using System;
using System.Linq;
using System.Text;

namespace _02_Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedString = Console.ReadLine();
            var decryptedString = new StringBuilder(encryptedString);

            for (int i = 0; i < decryptedString.Length; i++)
            {
                var currChar = decryptedString[i];
                var newChar = currChar - 3;

                decryptedString[i] = (char)newChar;
            }

            var twoSubstrings = Console.ReadLine().Split();
            var firstSubstring = twoSubstrings[0];
            var secondSubstring = twoSubstrings[1];

            var replacedString = decryptedString.Replace(firstSubstring, secondSubstring);
            var finalString = replacedString.ToString();


            bool isValid = encryptedString.All(c => "defghijklmnopqrstuvwxyz{}|#".Contains(c));

            if (isValid)
            {
                Console.WriteLine(finalString);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
