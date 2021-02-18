using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01_MostReliablePath
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second} {this.Weight}";
        }
    }

    public class Program
    {
        private static List<Edge>[] graph;

        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distances = new double[nodesCount];
            var prev = new int[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                distances[node] = double.NegativeInfinity;
                prev[node] = -1;
            }

            distances[source] = 100;

            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])));

            queue.Add(source);

            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();

                if (node == destination)
                {
                    break;
                }

                var children = graph[node];

                foreach (var edge in children)
                {
                    var child = edge.First == node
                        ? edge.Second
                        : edge.First;

                    if (double.IsNegativeInfinity(distances[child]))
                    {
                        queue.Add(child);
                    }

                    var newDistance = distances[node] * edge.Weight / 100.0;
                    if (newDistance > distances[child])
                    {
                        distances[child] = newDistance;
                        prev[child] = node;

                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])));
                    }
                }
            }

            Console.WriteLine($"Most reliable path reliability: {distances[destination]:F2}%");

            var path = ReconstructPath(prev, destination);
            Console.WriteLine(string.Join(" -> ", path));
        }

        private static Stack<int> ReconstructPath(int[] prev, int destination)
        {
            var path = new Stack<int>();

            while (destination != -1)
            {
                path.Push(destination);
                destination = prev[destination];
            }

            return path;
        }

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount];

            for (int node = 0; node < nodesCount; node++)
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
                var weight = edgeData[2];

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    Weight = weight
                };

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
