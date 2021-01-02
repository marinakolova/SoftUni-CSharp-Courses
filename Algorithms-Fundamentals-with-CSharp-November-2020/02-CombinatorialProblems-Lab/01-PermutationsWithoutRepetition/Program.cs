using System;

namespace _01_PermutationsWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;
        
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);            
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int elementsIndex = 0; elementsIndex < elements.Length; elementsIndex++)
            {
                if (!used[elementsIndex])
                {
                    used[elementsIndex] = true;
                    permutations[permutationsIndex] = elements[elementsIndex];
                    Permute(permutationsIndex + 1);
                    used[elementsIndex] = false;
                }
            }
        }
    }
}
