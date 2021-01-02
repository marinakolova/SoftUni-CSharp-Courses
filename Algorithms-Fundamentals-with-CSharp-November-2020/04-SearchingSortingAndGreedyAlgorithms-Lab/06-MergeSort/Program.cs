using System;
using System.Linq;

namespace _06_MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(" ", MergeSort(numbers)));
        }

        private static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            var copy = new int[array.Length];
            Array.Copy(array, copy, array.Length);

            MergeSortHelper(array, copy, 0, array.Length - 1);

            return array;
        }

        private static void MergeSortHelper(int[] source, int[] copy, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            var middleIndex = (leftIndex + rightIndex) / 2;
            MergeSortHelper(copy, source, leftIndex, middleIndex);
            MergeSortHelper(copy, source, middleIndex + 1, rightIndex);

            MergeArrays(source, copy, leftIndex, middleIndex, rightIndex);
        }

        private static void MergeArrays(int[] source, int[] copy, int startIndex, int middleIndex, int endIndex)
        {
            var sourceIndex = startIndex;
            var leftIndex = startIndex;
            var rightIndex = middleIndex + 1;

            while (leftIndex <= middleIndex && rightIndex <= endIndex)
            {
                if (copy[leftIndex] < copy[rightIndex])
                {
                    source[sourceIndex++] = copy[leftIndex++];
                }
                else
                {
                    source[sourceIndex++] = copy[rightIndex++];
                }
            }

            while (leftIndex <= middleIndex)
            {
                source[sourceIndex] = copy[leftIndex];
                leftIndex += 1;
                sourceIndex += 1;
            }

            while (rightIndex <= endIndex)
            {
                source[sourceIndex] = copy[rightIndex];
                rightIndex += 1;
                sourceIndex += 1;
            }
        }
    }
}
