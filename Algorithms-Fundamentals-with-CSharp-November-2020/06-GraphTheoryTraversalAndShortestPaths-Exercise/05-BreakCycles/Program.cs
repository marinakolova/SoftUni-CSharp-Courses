using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_BreakCycles
{
    class Program
    {
        private static List<Edge> edges;
        private static Dictionary<string, List<string>> graph;        
        
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            edges = new List<Edge>();
            graph = new Dictionary<string, List<string>>();

            ProcessInput(n);

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();

            var removedEdges = new List<Edge>();
            var blackListed = new HashSet<string>();

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    if (blackListed.Contains(edge.ToString()))
                    {
                        continue;
                    }
                    
                    removedEdges.Add(edge);
                    blackListed.Add(edge.ToStringReversed());
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);

            var visited = new HashSet<string> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
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

        private static void ProcessInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var node = parts[0];
                var children = parts[1].Split();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }
        }
    }

    public class Edge
    {
        public Edge(string first, string second)
        {
            this.First = first;
            this.Second = second;
        }

        public string First { get; set; }

        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }

        public string ToStringReversed()
        {
            return $"{this.Second} - {this.First}";
        }
    }
}
