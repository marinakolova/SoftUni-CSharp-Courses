using System;
using System.Text;

namespace _04_CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            StringBuilder text = new StringBuilder(input);

            for (int i = 0; i < text.Length; i++)
            {
                char newChar = (char)(text[i] + 3);
                text[i] = newChar;
            }

            Console.WriteLine(text);
        }
    }
}
