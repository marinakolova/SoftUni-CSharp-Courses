using System;

namespace _02_NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            GenArr(arr, 0);
        }

        private static void GenArr(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[index] = i + 1;

                GenArr(arr, index + 1);
            }
        }
    }
}
