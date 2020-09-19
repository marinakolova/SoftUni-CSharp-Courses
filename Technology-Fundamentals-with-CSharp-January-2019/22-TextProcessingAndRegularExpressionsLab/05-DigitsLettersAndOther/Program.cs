using System;

namespace _05_DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    Console.Write(line[i]);
                }
            }
            Console.WriteLine();

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i]))
                {
                    Console.Write(line[i]);
                }
            }
            Console.WriteLine();

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsSymbol(line[i]) || char.IsPunctuation(line[i]) || char.IsControl(line[i]))
                {
                    Console.Write(line[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
