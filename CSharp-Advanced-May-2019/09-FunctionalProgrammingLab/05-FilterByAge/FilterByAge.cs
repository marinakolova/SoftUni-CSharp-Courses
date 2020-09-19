using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var data = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var pair = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                data.Add(pair[0], int.Parse(pair[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filteredData = FilterDictionary(condition, age, data);
            Print(format, filteredData);
        }

        private static void Print(string format, List<KeyValuePair<string, int>> filteredData)
        {
            if (format == "name")
            {
                foreach (var item in filteredData)
                {
                    Console.WriteLine(item.Key);
                }
            }
            else if (format == "age")
            {
                foreach (var item in filteredData)
                {
                    Console.WriteLine(item.Value);
                }
            }
            else
            {
                foreach (var item in filteredData)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }

        private static List<KeyValuePair<string, int>> FilterDictionary(string condition, int age, Dictionary<string, int> data)
        {
            if (condition == "younger")
            {
                return data.Where(x => x.Value <= age).ToList();
            }
            else
            {
                return data.Where(x => x.Value >= age).ToList();
            }
        }
    }
}
