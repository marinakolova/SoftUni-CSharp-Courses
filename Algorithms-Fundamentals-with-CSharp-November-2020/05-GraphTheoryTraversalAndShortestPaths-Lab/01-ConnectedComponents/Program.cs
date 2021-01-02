using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ConnectedComponents
{
    class Program
    {
        static List<int>[] graph;
        static bool[] visited;
        
        static void Main(string[] args)
        {
            graph = ReadGraph();
            FindGraphConnectedComponents();
        }

        private static List<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }
            return graph;
        }

        private static void FindGraphConnectedComponents()
        {
            visited = new bool[graph.Length];

            for (int startNode = 0; startNode < graph.Count(); startNode++)
            {
                if (!visited[startNode])
                {
                    Console.Write("Connected component:");
                    DFS(startNode);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(int vertex)
        {
            if (!visited[vertex])
            {
                visited[vertex] = true;
                foreach (var child in graph[vertex])
                {
                    DFS(child);
                }

                Console.Write(" " + vertex);
            }
        }
    }
}
