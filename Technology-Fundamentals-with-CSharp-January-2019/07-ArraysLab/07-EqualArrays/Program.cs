using System;
using System.Linq;

namespace _07_EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

            int[] arr2 = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

            int sum = 0;
            int diffIndex = -1;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    sum += arr1[i];
                }

                if (arr1[i] != arr2[i])
                {
                    diffIndex = i;
                    break;
                }
            }

            if (diffIndex == -1)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {diffIndex} index");
            }
        }
    }
}
