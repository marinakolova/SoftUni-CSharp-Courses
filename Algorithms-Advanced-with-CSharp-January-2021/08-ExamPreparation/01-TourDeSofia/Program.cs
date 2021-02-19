using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01_TourDeSofia
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Distance { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;

        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());
            
            var startNode = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            var distances = new double[nodesCount];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = double.PositiveInfinity;
            }

            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));

            foreach (var edge in graph[startNode])
            {
                distances[edge.To] = edge.Distance;
                queue.Add(edge.To);
            }

            var visitedNodes = new HashSet<int> { startNode };

            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();
                visitedNodes.Add(node);

                if (node == startNode)
                {
                    break;
                }

                foreach (var edge in graph[node])
                {
                    var child = edge.To;

                    if (double.IsPositiveInfinity(distances[child]))
                    {
                        queue.Add(child);
                    }

                    var newDistance = distances[node] + edge.Distance;

                    if (newDistance < distances[child])
                    {
                        distances[child] = newDistance;

                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
                    }
                }
            }

            if (double.IsPositiveInfinity(distances[startNode]))
            {
                Console.WriteLine(visitedNodes.Count);
            }
            else
            {
                Console.WriteLine(distances[startNode]);
            }
        }

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount];

            for (int node = 0; node < result.Length; node++)
            {
                result[node] = new List<Edge>();
            }
            
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];
                var distance = edgeData[2];

                result[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Distance = distance
                });
            }

            return result;
        }
    }
}
