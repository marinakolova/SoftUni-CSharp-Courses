using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_SchoolTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsComb = new string[3];
            var girlsList = new List<string[]>();
            Comb(0, 0, girlsComb, girls, girlsList);

            var boysComb = new string[2];
            var boysList = new List<string[]>();
            Comb(0, 0, boysComb, boys, boysList);

            foreach (var currGirlsComb in girlsList)
            {
                foreach (var currBoysComb in boysList)
                {
                    Console.WriteLine($"{string.Join(", ", currGirlsComb)}, {string.Join(", ", currBoysComb)}");
                }
            }
        }

        private static void Comb(int cellIndex, int elementIndex, string[] combination, string[] elements, List<string[]> result)
        {
            if (cellIndex >= combination.Length)
            {
                result.Add(combination.ToArray());
                return;
            }

            for (int i = elementIndex; i < elements.Length; i++)
            {
                combination[cellIndex] = elements[i];
                Comb(cellIndex + 1, i + 1, combination, elements, result);
            }
        }
    }
}
