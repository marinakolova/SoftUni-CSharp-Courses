using System;
using System.Collections.Generic;

namespace _02_PermutationsWithRepetition
{
    class Program
    {
        private static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            Permute(0);
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(permutationsIndex + 1);
            var swapped = new HashSet<string> { elements[permutationsIndex] };
            for (int elementsIndex = permutationsIndex + 1; elementsIndex < elements.Length; elementsIndex++)
            {
                if (!swapped.Contains(elements[elementsIndex]))
                {
                    Swap(permutationsIndex, elementsIndex);
                    Permute(permutationsIndex + 1);
                    Swap(permutationsIndex, elementsIndex);
                    swapped.Add(elements[elementsIndex]);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
