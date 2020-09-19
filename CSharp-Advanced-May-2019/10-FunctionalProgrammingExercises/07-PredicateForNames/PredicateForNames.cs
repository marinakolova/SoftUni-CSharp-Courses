using System;

namespace _07_PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                if (name.Length <= n)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
