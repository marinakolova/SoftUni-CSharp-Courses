using System;

namespace _02_AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            var charOne = char.Parse(Console.ReadLine());
            var charTwo = char.Parse(Console.ReadLine());

            var line = Console.ReadLine();

            int charOneAscii = charOne;
            int charTwoAscii = charTwo;

            int sum = 0;
            
            for (int i = 0; i < line.Length; i++)
            {
                char currChar = line[i];
                int currCharAscii = currChar;

                if (charOneAscii < charTwo)
                {
                    if (currCharAscii > charOneAscii && currCharAscii < charTwoAscii)
                    {
                        sum += currCharAscii;
                    }
                }
                else if (charOneAscii > charTwoAscii)
                {
                    if (currCharAscii < charOneAscii && currCharAscii > charTwoAscii)
                    {
                        sum += currCharAscii;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
