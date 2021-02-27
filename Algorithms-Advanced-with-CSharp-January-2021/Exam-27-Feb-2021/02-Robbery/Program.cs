using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02_Robbery
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Distance { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;
        private static bool[] cameras;

        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());
            
            graph = ReadGraph(nodesCount, edgesCount);
            cameras = ReadCameras(nodesCount);

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            var distances = new double[nodesCount];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = double.PositiveInfinity;
            }

            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));

            distances[startNode] = 0;
            queue.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();

                if (node == endNode)
                {
                    break;
                }

                foreach (var edge in graph[node])
                {
                    var child = edge.First == node
                        ? edge.Second
                        : edge.First;

                    if (cameras[child])
                    {
                        continue;
                    }

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

            Console.WriteLine(distances[endNode]);
        }

        private static bool[] ReadCameras(int nodesCount)
        {
            var result = new bool[nodesCount];

            var line = Console.ReadLine().Split();

            for (int i = 0; i < line.Length; i++)
            {
                var blackOrWhite = line[i][1];

                if (blackOrWhite == 'b')
                {
                    result[i] = false;
                }
                else
                {
                    result[i] = true;
                }
            }

            return result;
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

                var first = edgeData[0];
                var second = edgeData[1];
                var distance = edgeData[2];

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    Distance = distance
                };

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
