using System;
using System.Collections.Generic;

namespace _04_Salaries
{
    class Program
    {
        private static List<int>[] graph;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            var totalSalary = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                var salary = GetSalary(node);
                totalSalary += salary;
            }

            Console.WriteLine(totalSalary);
        }

        private static int GetSalary(int node)
        {
            var children = graph[node];

            if (children.Count == 0)
            {
                return 1;
            }

            var salary = 0;
            foreach (var child in children)
            {
                salary += GetSalary(child);
            }

            return salary;
        }

        private static List<int>[] ReadGraph(int n)
        {
            var result = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                var children = new List<int>();

                var sequence = Console.ReadLine();

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == 'Y')
                    {
                        children.Add(i);
                    }
                }

                result[node] = children;
            }

            return result;
        }
    }
}
