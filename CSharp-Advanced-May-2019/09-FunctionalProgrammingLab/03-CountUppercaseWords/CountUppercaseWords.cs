using System;
using System.Linq;

namespace _03_CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
