using System;
using System.Text;

namespace _04_TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine().Split(", ");
            var text = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {
                var asteriks = new String('*', bannedWord.Length);

                while (text.Contains(bannedWord))
                {
                    text = text.Replace(bannedWord, asteriks);
                }
            }

            Console.WriteLine(text);
        }
    }
}
