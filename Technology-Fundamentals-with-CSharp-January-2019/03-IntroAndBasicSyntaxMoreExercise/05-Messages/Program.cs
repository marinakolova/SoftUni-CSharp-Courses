using System;

namespace _05_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputRows = int.Parse(Console.ReadLine());
            string input = "";
            string output = "";

            for (int i = 1; i <= inputRows; i++)
            {
                input = Console.ReadLine();

                int numOfDigits = input.Length;
                int number = int.Parse(input);
                int mainDigit = number % 10;
                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                int letterIndex = offset + numOfDigits - 1;
                int asciiCode = 97 + letterIndex;

                if (number != 0)
                    output += (char)asciiCode;
                else if (number == 0)
                    output += " ";
            }

            Console.WriteLine(output);
        }        
    }
}
