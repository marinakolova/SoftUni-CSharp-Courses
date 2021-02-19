using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_RoadTrip
{
    public class Item
    {
        public int Value { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Item> items;
        private static int[,] table;

        public static void Main(string[] args)
        {
            items = ReadInput();
            var maxCapacity = int.Parse(Console.ReadLine());            

            table = new int[items.Count + 1, maxCapacity + 1];
            FillTable();

            var totalValue = 0;

            var row = table.GetLength(0) - 1;
            var col = table.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    var selectedItem = items[row - 1];

                    totalValue += selectedItem.Value;

                    col -= selectedItem.Weight;
                }

                row -= 1;
            }

            Console.WriteLine($"Maximum value: {totalValue}");
        }

        private static void FillTable()
        {
            for (int itemIndex = 1; itemIndex < table.GetLength(0); itemIndex++)
            {
                var currentItem = items[itemIndex - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (capacity < currentItem.Weight)
                    {
                        table[itemIndex, capacity] = table[itemIndex - 1, capacity];
                    }
                    else
                    {
                        table[itemIndex, capacity] = Math.Max(
                            table[itemIndex - 1, capacity],
                            table[itemIndex - 1, capacity - currentItem.Weight] + currentItem.Value);
                    }
                }
            }
        }

        private static List<Item> ReadInput()
        {
            var result = new List<Item>();

            var values = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var weights = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                var weight = weights[i];

                result.Add(new Item 
                {
                    Value = value,
                    Weight = weight
                });
            }

            return result;
        }
    }
}
