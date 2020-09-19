using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook_03_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceUsers = new Dictionary<string, List<string>>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                string[] data = input.Split(new char[] { '|', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains('|'))
                {
                    string side = data[0].Trim();
                    string user = data[1].Trim();

                    if (forceUsers.ContainsKey(side) == false)
                    {
                        if (forceUsers.Values.Any(x => x.Contains(user)))
                        {
                            continue;
                        }

                        forceUsers.Add(side, new List<string>());
                    }

                    if (forceUsers[side].Contains(user) == false)
                    {
                        forceUsers[side].Add(user);
                    }

                }
                else if (input.Contains('>'))
                {
                    string user = data[0].Trim();
                    string side = data[1].Trim();

                    if (forceUsers.ContainsKey(side))
                    {
                        if (forceUsers[side].Contains(user))
                        {
                            continue;
                        }
                    }

                    foreach (var unit in forceUsers.Values)
                    {
                        if (unit.Contains(user))
                        {
                            unit.Remove(user);
                        }
                    }

                    if (forceUsers.ContainsKey(side) == false)
                    {
                        forceUsers.Add(side, new List<string>());
                    }

                    forceUsers[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            forceUsers = forceUsers.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var army in forceUsers)
            {
                string side = army.Key;
                List<string> soldiers = army.Value.OrderBy(s => s).ToList();

                if (soldiers.Count > 0)
                {
                    Console.WriteLine($"Side: {side}, Members: {soldiers.Count}");

                    foreach (var member in soldiers)
                    {
                        Console.WriteLine($"! {member}");
                    }
                }
            }
        }
    }
}