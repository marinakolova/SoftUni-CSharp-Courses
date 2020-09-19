using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            var birthdates = new List<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    birthdates.Add(tokens[4]);
                }
                else if (tokens[0] == "Pet")
                {
                    birthdates.Add(tokens[2]);
                }
            }

            var year = Console.ReadLine();

            if (birthdates.Where(x => x.EndsWith(year)).ToList().Count > 0)
            {
                foreach (var date in birthdates.Where(x => x.EndsWith(year)))
                {
                    Console.WriteLine(date);
                }
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
