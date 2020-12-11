using System;
using System.Linq;

namespace _01_RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = GetSum(arr, 0);

            Console.WriteLine(result);
        }

        private static int GetSum(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return 0;
            }

            return arr[index] + GetSum(arr, index + 1);
        }
    }
}
