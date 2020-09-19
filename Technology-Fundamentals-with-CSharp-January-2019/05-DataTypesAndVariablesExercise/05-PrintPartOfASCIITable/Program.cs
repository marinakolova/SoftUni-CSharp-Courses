using System;

namespace _05_PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstChar = int.Parse(Console.ReadLine());
            int lastChar = int.Parse(Console.ReadLine());

            for (int i = firstChar; i <= lastChar; i++)
            {
                char charToPrint = (char)i;
                Console.Write($"{charToPrint} ");
            }

            Console.WriteLine();
        }
    }
}
