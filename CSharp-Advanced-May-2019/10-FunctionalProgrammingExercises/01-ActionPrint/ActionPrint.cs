using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> printer = x => x.ForEach(Console.WriteLine);

            printer(input);
        }
    }
}
