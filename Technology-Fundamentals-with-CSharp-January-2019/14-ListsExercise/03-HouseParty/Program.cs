using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < n; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                switch (commands[2])
                {
                    case "going!":
                        if (guests.Contains(commands[0]))
                        {
                            Console.WriteLine($"{commands[0]} is already in the list!");
                        }
                        else
                        {
                            guests.Add(commands[0]);
                        }
                        break;

                    case "not":
                        if (guests.Contains(commands[0]))
                        {
                            guests.Remove(commands[0]);
                        }
                        else
                        {
                            Console.WriteLine($"{commands[0]} is not in the list!");
                        }
                        break;
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
