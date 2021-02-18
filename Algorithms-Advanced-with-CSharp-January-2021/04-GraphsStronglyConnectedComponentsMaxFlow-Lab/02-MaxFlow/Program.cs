using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_MaxFlow
{
    public class Program
    {
        private static int[,] graph;
        private static int[] parents;
        
        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount);

            var source = int.Parse(Console.ReadLine());
            var target = int.Parse(Console.ReadLine());

            parents = new int[nodesCount];
            Array.Fill(parents, -1);

            var maxFlow = 0;

            while (BFS(source, target))
            {
                // Find min flow
                var currentFlow = GetCurrentFlow(source, target);

                // max flow += min flow
                maxFlow += currentFlow;

                // Modify capacities
                ApplyCurrentFlow(source, target, currentFlow);
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void ApplyCurrentFlow(int source, int target, int flow)
        {
            var node = target;

            while (node != source)
            {
                var parent = parents[node];

                graph[parent, node] -= flow;

                node = parent;
            }
        }

        private static int GetCurrentFlow(int source, int target)
        {
            var node = target;
            var minFlow = int.MaxValue;

            while (node != source)
            {
                var parent = parents[node];

                var flow = graph[parent, node];

                if (flow < minFlow)
                {
                    minFlow = flow;
                }

                node = parent;
            }

            return minFlow;
        }

        private static bool BFS(int source, int target)
        {
            var queue = new Queue<int>();
            var visited = new bool[graph.GetLength(0)];

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child]
                        && graph[node, child] > 0)
                    {
                        visited[child] = true;
                        
                        queue.Enqueue(child);
                        
                        parents[child] = node;
                    }
                }                
            }

            return visited[target];
        }

        private static int[,] ReadGraph(int nodesCount)
        {
            var result = new int[nodesCount, nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                var capacities = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int child = 0; child < capacities.Length; child++)
                {
                    var capacity = capacities[child];

                    result[node, child] = capacity;
                }
            }

            return result;
        }
    }
}
