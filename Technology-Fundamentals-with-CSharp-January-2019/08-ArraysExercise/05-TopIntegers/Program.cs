using System;
using System.Linq;

namespace _05_TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] outputArr = new int[10];
            int outputArrIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                bool isTop = true;

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] <= input[j])
                    {
                        isTop = false;
                    }                    
                }

                if (isTop)
                {
                    outputArr[outputArrIndex] = input[i];
                    outputArrIndex++;
                }
            }

            for (int k = 0; k < outputArrIndex; k++)
            {
                Console.Write(outputArr[k] + " ");
            }
            Console.WriteLine();
        }
    }
}
