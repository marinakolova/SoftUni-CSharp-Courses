using System;
using System.Linq;

namespace _03_BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length - i; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        Swap(numbers, j - 1, j);
                    }
                }
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
