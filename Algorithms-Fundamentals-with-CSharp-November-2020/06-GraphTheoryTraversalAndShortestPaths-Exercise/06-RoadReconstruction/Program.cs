using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_RoadReconstruction
{
    class Program
    {
        private static Dictionary<int, List<int>> buildings;
        private static HashSet<Street> streets;

        static void Main(string[] args)
        {
            buildings = new Dictionary<int, List<int>>();
            streets = new HashSet<Street>();

            ProcessInput();

            var importantStreets = new List<Street>();

            foreach (var street in streets)
            {
                var first = street.First;
                var second = street.Second;

                buildings[first].Remove(second);
                buildings[second].Remove(first);

                if (!HasPath(first, second))
                {
                    importantStreets.Add(street);
                }
                else
                {
                    buildings[first].Add(second);
                    buildings[second].Add(first);
                }
            }

            Console.WriteLine("Important streets:");
            foreach (var street in importantStreets)
            {
                Console.WriteLine($"{street.First} {street.Second}");
            }
        }

        private static bool HasPath(int source, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(source);

            var visited = new HashSet<int> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in buildings[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        private static void ProcessInput()
        {
            var numOfBuildings = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfBuildings; i++)
            {
                buildings.Add(i, new List<int>());
            }

            var amountOfStreets = int.Parse(Console.ReadLine());
            for (int i = 0; i < amountOfStreets; i++)
            {
                var parts = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                var firstBuilding = int.Parse(parts[0]);
                var secondBuilding = int.Parse(parts[1]);

                streets.Add(new Street(firstBuilding, secondBuilding));
                buildings[firstBuilding].Add(secondBuilding);
                buildings[secondBuilding].Add(firstBuilding);
            }
        }
    }

    public class Street
    {
        public Street(int firstBuilding, int secondBuilding)
        {
            if (firstBuilding < secondBuilding)
            {
                this.First = firstBuilding;
                this.Second = secondBuilding;
            }
            else
            {
                this.First = secondBuilding;
                this.Second = firstBuilding;
            }
        }

        public int First { get; set; }

        public int Second { get; set; }
    }
}