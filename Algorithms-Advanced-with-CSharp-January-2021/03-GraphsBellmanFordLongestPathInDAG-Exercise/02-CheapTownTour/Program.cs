using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CheapTownTour
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

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

            var sortedEdges = edges
                .OrderBy(e => e.Weight)
                .ToList();

            var root = new int[nodesCount];
            for (int node = 0; node < nodesCount; node++)
            {
                root[node] = node;
            }

            var totalCost = 0;

            foreach (var edge in sortedEdges)
            {
                var firstRoot = GetRoot(edge.First, root);
                var secondRoot = GetRoot(edge.Second, root);

                if (firstRoot != secondRoot)
                {
                    root[firstRoot] = secondRoot;
                    totalCost += edge.Weight;
                }
            }

            Console.WriteLine($"Total cost: {totalCost}");
        }

        private static int GetRoot(int node, int[] root)
        {
            while (node != root[node])
            {
                node = root[node];
            }

            return node;
        }

        private static List<Edge> ReadEdges(int edgesCount)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2];

                result.Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = weight
                });
            }

            return result;
        }
    }
}
