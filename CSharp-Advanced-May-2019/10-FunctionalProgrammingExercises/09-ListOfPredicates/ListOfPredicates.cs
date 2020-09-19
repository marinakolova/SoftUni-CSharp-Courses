using System;
using System.Linq;

namespace _09_ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 1; i <= n; i++)
            {
                bool isDivisible = true;

                foreach (var divider in dividers)
                {
                    if (i % divider != 0)
                    {
                        isDivisible = false;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
