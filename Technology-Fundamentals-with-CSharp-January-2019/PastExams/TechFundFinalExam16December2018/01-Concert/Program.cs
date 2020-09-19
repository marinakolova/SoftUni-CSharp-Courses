using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var bandMembers = new Dictionary<string, List<string>>();
            var bandTimes = new Dictionary<string, int>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "start of concert")
                {
                    break;
                }

                var partsOfCommand = command.Split("; ");

                if (partsOfCommand[0] == "Add")
                {
                    var band = partsOfCommand[1];
                    var members = partsOfCommand[2].Split(", ").ToList();

                    if (!bandMembers.ContainsKey(band))
                    {
                        bandMembers.Add(band, new List<string>());
                    }
                    foreach (var member in members)
                    {
                        if (!bandMembers[band].Contains(member))
                        {
                            bandMembers[band].Add(member);
                        }
                    }
                }

                else if (partsOfCommand[0] == "Play")
                {
                    var band = partsOfCommand[1];
                    var time = int.Parse(partsOfCommand[2]);

                    if (!bandTimes.ContainsKey(band))
                    {
                        bandTimes.Add(band, 0);
                    }
                    bandTimes[band] += time;
                }
            }

            var bandToPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {bandTimes.Values.Sum()}");

            foreach (var band in bandTimes.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            Console.WriteLine(bandToPrint);

            foreach (var member in bandMembers[bandToPrint])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
