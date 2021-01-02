using System;
using System.Linq;

namespace _05_Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            var pivotIndex = startIndex;
            var leftIndex = startIndex + 1;
            var rightIndex = endIndex;

            while (leftIndex <= rightIndex)
            {
                if (numbers[leftIndex] > numbers[pivotIndex] &&
                    numbers[rightIndex] < numbers[pivotIndex])
                {
                    Swap(numbers, leftIndex, rightIndex);
                }

                if (numbers[leftIndex] <= numbers[pivotIndex])
                {
                    leftIndex += 1;
                }

                if (numbers[rightIndex] >= numbers[pivotIndex])
                {
                    rightIndex -= 1;
                }
            }

            Swap(numbers, pivotIndex, rightIndex);

            var isLeftSubArraysSmaller = rightIndex - 1 - startIndex < endIndex - (rightIndex + 1);

            if (isLeftSubArraysSmaller)
            {
                QuickSort(numbers, startIndex, rightIndex - 1);
                QuickSort(numbers, rightIndex + 1, endIndex);
            }
            else
            {
                QuickSort(numbers, rightIndex + 1, endIndex);
                QuickSort(numbers, startIndex, rightIndex - 1);
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
