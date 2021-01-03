using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_TheStoryTelling
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            dependencies = ExtractDependencies(graph);

            var sorted = TopologicalSort();
            
            Console.WriteLine(string.Join(" ", sorted));
        }

        private static List<string> TopologicalSort()
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.Reverse()
                    .FirstOrDefault(n => n.Value == 0)
                    .Key;

                dependencies.Remove(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child] -= 1;
                }

                sorted.Add(nodeToRemove);
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> inputGraph)
        {
            var result = new Dictionary<string, int>();

            foreach (var node in inputGraph.Keys)
            {
                if (!result.ContainsKey(node))
                {
                    result.Add(node, 0);
                }

                foreach (var child in graph[node])
                {
                    if (!result.ContainsKey(child))
                    {
                        result.Add(child, 1);
                    }
                    else
                    {
                        result[child] += 1;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();
            
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var parts = line
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                var preStory = parts[0].Trim();

                if (!result.ContainsKey(preStory))
                {
                    result.Add(preStory, new List<string>());
                }

                if (parts.Length == 1)
                {
                    continue;
                }
                
                var postStories = parts[1].Trim()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                result[preStory].AddRange(postStories);
            }

            return result;
        }
    }
}
