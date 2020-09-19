using System;

namespace _07_RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());
            RepeatString(str, repeatCount);
        }

        private static void RepeatString(string str, int repeatCount)
        {
            string repeatedString = "";

            for (int i = 0; i < repeatCount; i++)
            {
                repeatedString += str;
            }

            Console.WriteLine(repeatedString);
        }
    }
}
