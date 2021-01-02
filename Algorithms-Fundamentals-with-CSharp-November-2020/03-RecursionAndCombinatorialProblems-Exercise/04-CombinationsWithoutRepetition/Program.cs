using System;

namespace _04_CombinationsWithoutRepetition
{
    class Program
    {
        private static int[] elements;
        private static int k;
        private static int[] combinations;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            elements = new int[n];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = i + 1;
            }

            k = int.Parse(Console.ReadLine());
            combinations = new int[k];

            Combinations(0, 0);
        }

        private static void Combinations(int combIndex, int elementsStartIndex)
        {
            if (combIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[combIndex] = elements[i];
                Combinations(combIndex + 1, i + 1);
            }
        }
    }
}
