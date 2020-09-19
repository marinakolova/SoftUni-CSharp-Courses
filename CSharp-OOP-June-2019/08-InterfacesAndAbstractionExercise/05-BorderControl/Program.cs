using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            var allIds = new List<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    allIds.Add(tokens[2]);
                }
                else if (tokens.Length == 2)
                {
                    allIds.Add(tokens[1]);
                }
            }

            var lastDigitOfFakeIds = Console.ReadLine();

            foreach (var id in allIds.Where(x => x.EndsWith(lastDigitOfFakeIds)))
            {
                Console.WriteLine(id);
            }
        }
    }
}
