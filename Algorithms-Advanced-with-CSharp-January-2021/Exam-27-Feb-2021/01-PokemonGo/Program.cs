using System;
using System.Collections.Generic;

namespace _01_PokemonGo
{
    public class Street
    {
        public string Name { get; set; }        

        public int Value { get; set; }

        public int Length { get; set; }
    }

    public class Program
    {
        private static List<Street> streets;
        private static int[,] table;

        public static void Main(string[] args)
        {
            var maxFuel = int.Parse(Console.ReadLine());
            streets = ReadInput();

            table = new int[streets.Count + 1, maxFuel + 1];
            FillTable();

            var selectedStreets = new SortedSet<string>();
            var usedFuel = 0;
            var totalValue = 0;

            var row = table.GetLength(0) - 1;
            var col = table.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    var selectedItem = streets[row - 1];

                    selectedStreets.Add(selectedItem.Name);
                    usedFuel += selectedItem.Length;
                    totalValue += selectedItem.Value;

                    col -= selectedItem.Length;
                }

                row -= 1;
            }

            if (selectedStreets.Count > 0)
            {
                Console.WriteLine(string.Join(" -> ", selectedStreets));
            }
            Console.WriteLine($"Total Pokemon caught -> {totalValue}");
            Console.WriteLine($"Fuel Left -> {maxFuel - usedFuel}");
            
        }

        private static void FillTable()
        {
            for (int itemIndex = 1; itemIndex < table.GetLength(0); itemIndex++)
            {
                var currentItem = streets[itemIndex - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (capacity < currentItem.Length)
                    {
                        table[itemIndex, capacity] = table[itemIndex - 1, capacity];
                    }
                    else
                    {
                        table[itemIndex, capacity] = Math.Max(
                            table[itemIndex - 1, capacity],
                            table[itemIndex - 1, capacity - currentItem.Length] + currentItem.Value);
                    }
                }
            }
        }

        private static List<Street> ReadInput()
        {
            var result = new List<Street>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var parts = line
                    .Split(", ");
                
                var name = parts[0];
                var value = int.Parse(parts[1]);
                var lenght = int.Parse(parts[2]);

                result.Add(new Street
                {
                    Name = name,
                    Value = value,
                    Length = lenght
                });
            }

            return result;
        }
    }
}
