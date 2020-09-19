using System;

namespace _1_RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                PrintRow(i, count);
            }

            for (int i = count - 1; i > 0; i--)
            {
                PrintRow(i, count);
            }
        }

        private static void PrintRow(int stars, int totalStars)
        {
            int leadingSpaces = totalStars - stars;
            Console.Write(new string(' ', leadingSpaces));

            for (int i = 0; i < stars; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
