using System;

namespace _01_ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split();

            ReverseArray(arr, 0, arr.Length - 1);
        }

        private static void ReverseArray(string[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            Swap(arr, startIndex, endIndex);
            ReverseArray(arr, startIndex + 1, endIndex - 1);
        }

        private static void Swap(string[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
