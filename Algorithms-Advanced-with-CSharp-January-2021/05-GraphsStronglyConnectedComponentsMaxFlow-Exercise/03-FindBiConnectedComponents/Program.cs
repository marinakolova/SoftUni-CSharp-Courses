using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_FindBiConnectedComponents
{
    public class Program
    {
        private static List<int>[] graph;
        private static int[] depths;
        private static int[] lowpoint;        
        private static bool[] visited;
        private static int[] parent;

        private static Stack<int> stack;
        private static List<HashSet<int>> components;

        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            depths = new int[nodesCount];
            lowpoint = new int[nodesCount];
            visited = new bool[nodesCount];

            parent = new int[nodesCount];
            Array.Fill(parent, -1);

            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    FindArticulationPoint(node, 1);

                    var component = new HashSet<int>();

                    while (stack.Count > 1)
                    {
                        var stackChild = stack.Pop();
                        var stackNode = stack.Pop();

                        component.Add(stackNode);
                        component.Add(stackChild);
                    }

                    components.Add(component);
                }
            }

            Console.WriteLine($"Number of bi-connected components: {components.Count}");

            //foreach (var component in components)
            //{
            //    Console.WriteLine(string.Join(" ", component));
            //}
        }

        private static void FindArticulationPoint(int node, int depth)
        {
            visited[node] = true;            
            depths[node] = depth;
            lowpoint[node] = depth;

            var childCount = 0;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parent[child] = node;
                    childCount += 1;
                    
                    FindArticulationPoint(child, depth + 1);

                    if ((parent[node] == -1 && childCount > 1) ||
                        (parent[node] != -1 && lowpoint[child] >= depth))
                    {
                        var component = new HashSet<int>();
                        
                        while (true)
                        {
                            var stackChild = stack.Pop();
                            var stackNode = stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackNode == node &&
                                stackChild == child)
                            {
                                break;
                            }
                        }

                        components.Add(component);
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child &&
                    depths[child] < lowpoint[node])
                {
                    lowpoint[node] = depths[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }

        private static List<int>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<int>[nodesCount];

            for (int node = 0; node < result.Length; node++)
            {
                result[node] = new List<int>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var first = edge[0];
                var second = edge[1];
                
                result[first].Add(second);
                result[second].Add(first);
            }

            return result;
        }
    }
}
