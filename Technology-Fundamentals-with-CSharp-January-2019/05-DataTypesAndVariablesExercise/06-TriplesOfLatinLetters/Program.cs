using System;

namespace _06_TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstLetter = 97;
            int lastLetter = 96 + n;
            string oneLetter = "";
            string twoLetters = "";
            string threeLetters = "";
            
            for (int i = firstLetter; i <= lastLetter; i++)
            {
                char firstChar = (char)i;
                oneLetter += firstChar;
                
                for (int j = firstLetter; j <= lastLetter; j++)
                {
                    char secondChar = (char)j;
                    twoLetters = oneLetter + secondChar;
                    
                    for (int k = firstLetter; k <= lastLetter; k++)
                    {
                        char thirdChar = (char)k;
                        threeLetters = twoLetters + thirdChar;

                        Console.WriteLine(threeLetters);

                        threeLetters = twoLetters;
                    }

                    twoLetters = oneLetter;
                }

                oneLetter = "";
            }
        }
    }
}
