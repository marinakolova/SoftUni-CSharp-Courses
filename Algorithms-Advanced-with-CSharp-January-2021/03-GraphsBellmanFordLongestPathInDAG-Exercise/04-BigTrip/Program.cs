using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_BigTrip
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.From} {this.To} {this.Weight}";
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

            var sortedNodes = TopologicalSorting();

            var distances = new double[graph.Length];
            Array.Fill(distances, double.NegativeInfinity);

            distances[source] = 0;

            var prev = new int[nodesCount + 1];
            Array.Fill(prev, -1);

            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distances[node] + edge.Weight;

                    if (newDistance > distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = edge.From;
                    }
                }
            }

            Console.WriteLine(distances[destination]);

            var path = ReconstructPath(prev, destination);
            Console.WriteLine(string.Join(" ", path));
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

        private static Stack<int> TopologicalSorting()
        {
            var visited = new bool[graph.Length];
            var sorted = new Stack<int>();

            for (int node = 1; node < graph.Length; node++)
            {
                DFS(node, visited, sorted);
            }

            return sorted;
        }

        private static void DFS(int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var edge in graph[node])
            {
                DFS(edge.To, visited, sorted);
            }

            sorted.Push(node);
        }

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount + 1];

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
                var weight = edgeData[2];

                result[from].Add(new Edge
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
