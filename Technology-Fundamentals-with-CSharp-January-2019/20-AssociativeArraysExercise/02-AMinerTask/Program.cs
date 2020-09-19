using System;
using System.Collections.Generic;

namespace _02_AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();

            while (true)
            {
                string oddLine = Console.ReadLine();

                if (oddLine == "stop")
                {
                    break;
                }

                int evenLine = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(oddLine))
                {
                    resources[oddLine] += evenLine;
                }
                else
                {
                    resources.Add(oddLine, evenLine);
                }
            }

            foreach (var res in resources)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }
    }
}
