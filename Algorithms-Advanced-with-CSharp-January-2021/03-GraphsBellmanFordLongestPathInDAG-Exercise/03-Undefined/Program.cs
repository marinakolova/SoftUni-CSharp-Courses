using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Undefined
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Edge> edges;

        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = ReadEdges(edgesCount);            

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distances = new double[nodesCount + 1];
            Array.Fill(distances, double.PositiveInfinity);

            distances[source] = 0;

            var prev = new int[nodesCount + 1];
            Array.Fill(prev, -1);

            for (int i = 0; i < nodesCount - 1; i++)
            {
                var updated = false;

                foreach (var edge in edges)
                {
                    if (double.IsPositiveInfinity(edge.From))
                    {
                        continue;
                    }

                    var newDistance = distances[edge.From] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = edge.From;

                        updated = true;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            foreach (var edge in edges)
            {
                if (double.IsPositiveInfinity(edge.From))
                {
                    continue;
                }

                var newDistance = distances[edge.From] + edge.Weight;
                if (newDistance < distances[edge.To])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            var path = ReconstructPath(prev, destination);

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distances[destination]);

        }

        private static Stack<int> ReconstructPath(int[] prev, int destination)
        {
            var path = new Stack<int>();
            var node = destination;

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            return path;
        }

        private static List<Edge> ReadEdges(int edgesCount)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];
                var weight = edgeData[2];

                result.Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = weight
                });
            }

            return result;
        }
    }
}
