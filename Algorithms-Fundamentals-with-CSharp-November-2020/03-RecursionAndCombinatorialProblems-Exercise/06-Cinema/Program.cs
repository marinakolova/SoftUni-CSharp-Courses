using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Cinema
{
    class Program
    {
        private static List<string> names;
        private static string[] seats;
        private static HashSet<int> lockedSeats;
        
        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ")
                .ToList();

            seats = new string[names.Count];
            lockedSeats = new HashSet<int>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "generate")
                {
                    break;
                }

                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                names.Remove(name);
                seats[position] = name;
                lockedSeats.Add(position);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                // List<string> names -> current permutation
                PrintResult();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintResult()
        {
            var namesIndex = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (lockedSeats.Contains(i))
                {
                    continue;
                }

                seats[i] = names[namesIndex];
                namesIndex += 1;
            }

            Console.WriteLine(string.Join(" ", seats));
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}
