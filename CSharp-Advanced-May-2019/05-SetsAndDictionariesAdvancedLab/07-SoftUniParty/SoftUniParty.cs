using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07_SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }

                if (Regex.IsMatch(input, @"^\d+"))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (Regex.IsMatch(input, @"^\d+"))
                {
                    if (vip.Contains(input))
                    {
                        vip.Remove(input);
                    }
                }
                else
                {
                    if (regular.Contains(input))
                    {
                        regular.Remove(input);
                    }
                }
            }

            Console.WriteLine(vip.Count + regular.Count);

            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
