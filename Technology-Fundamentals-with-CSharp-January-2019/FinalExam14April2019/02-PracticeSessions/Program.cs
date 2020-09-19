using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            var roads = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var partsOfInput = input.Split("->");

                if (partsOfInput[0] == "Add")
                {
                    var roadToAdd = partsOfInput[1];
                    var racerToAdd = partsOfInput[2];

                    if (!roads.ContainsKey(roadToAdd))
                    {
                        roads.Add(roadToAdd, new List<string>());
                    }
                    roads[roadToAdd].Add(racerToAdd);                    
                }

                else if (partsOfInput[0] == "Move")
                {
                    var currRoad = partsOfInput[1];
                    var racerToMove = partsOfInput[2];
                    var nextRoad = partsOfInput[3];

                    if (roads[currRoad].Contains(racerToMove))
                    {
                        roads[currRoad].Remove(racerToMove);
                        roads[nextRoad].Add(racerToMove);                        
                    }
                }

                else if (partsOfInput[0] == "Close")
                {
                    var roadToClose = partsOfInput[1];

                    if (roads.ContainsKey(roadToClose))
                    {
                        roads.Remove(roadToClose);
                    }
                }
            }

            Console.WriteLine("Practice sessions:");
            foreach (var road in roads.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(road.Key);
                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
