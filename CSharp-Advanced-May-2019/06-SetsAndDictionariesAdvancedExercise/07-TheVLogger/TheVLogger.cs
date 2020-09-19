using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, List<List<string>>>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Statistics")
                {
                    break;
                }

                var partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (partsOfCommand[1] == "joined")
                {
                    if (!vloggers.ContainsKey(partsOfCommand[0]))
                    {
                        vloggers.Add(partsOfCommand[0], new List<List<string>>());
                        vloggers[partsOfCommand[0]].Add(new List<string>());
                        vloggers[partsOfCommand[0]].Add(new List<string>());
                    }
                }

                else
                {
                    var follower = partsOfCommand[0];
                    var vlogger = partsOfCommand[2];

                    if (vloggers.ContainsKey(follower) && vloggers.ContainsKey(vlogger)
                        && follower != vlogger
                        && !vloggers[vlogger][0].Contains(follower))
                    {
                        vloggers[vlogger][0].Add(follower);
                        vloggers[follower][1].Add(vlogger);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int counter = 0;

            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value[0].Count).ThenBy(x => x.Value[1].Count))
            {
                counter++;

                if (counter == 1)
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value[0].Count} followers, {vlogger.Value[1].Count} following");

                    foreach (var follower in vlogger.Value[0].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                else
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value[0].Count} followers, {vlogger.Value[1].Count} following");
                }
            }
        }
    }
}
