using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_PathFinder
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());            
            graph = ReadGraph(n);

            var p = int.Parse(Console.ReadLine());
            for (int i = 0; i < p; i++)
            {
                var path = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (CheckPath(path))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static bool CheckPath(int[] path)
        {
            for (int i = 0; i < path.Length - 1; i++)
            {
                if (!HasDirectPath(path[i], path[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool HasDirectPath(int source, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(source);
            var visited = new HashSet<int> { source };
            
            foreach (var child in graph[source])
            {
                if (visited.Contains(child))
                {
                    continue;
                }

                visited.Add(child);
                queue.Enqueue(child);
            }            

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }
            }

            return false;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var result = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                result.Add(i, new List<int>());
            }
            for (int i = 0; i < n; i++)
            {
                result[i].AddRange(Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }
            return result;
        }
    }
}
