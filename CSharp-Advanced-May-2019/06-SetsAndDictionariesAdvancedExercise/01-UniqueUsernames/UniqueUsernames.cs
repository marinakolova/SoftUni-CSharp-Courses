using System;
using System.Collections.Generic;

namespace _01_UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var names = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var name = Console.ReadLine();
                if (!names.Contains(name))
                {
                    names.Add(name);
                }
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
