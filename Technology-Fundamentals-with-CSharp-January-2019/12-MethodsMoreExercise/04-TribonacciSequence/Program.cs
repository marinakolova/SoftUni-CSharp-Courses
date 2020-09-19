using System;
using System.Linq;
using System.Numerics;

namespace _04_TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintNthTribonacciNumber(n);
        }

        private static void PrintNthTribonacciNumber(int n)
        {
            long[] sequnceLast3Nums = new long[3];
            sequnceLast3Nums[0] = 1;
            sequnceLast3Nums[1] = 1;
            sequnceLast3Nums[2] = 2;

            for (int i = 0; i < n; i++)
            {
                if (i > 2)
                {
                    long temp = sequnceLast3Nums[0];
                    sequnceLast3Nums[0] = sequnceLast3Nums[1];
                    sequnceLast3Nums[1] = sequnceLast3Nums[2];
                    sequnceLast3Nums[2] = sequnceLast3Nums[0] + sequnceLast3Nums[1] + temp;

                    Console.Write($"{sequnceLast3Nums[2]} ");
                }
                else
                {
                    Console.Write($"{sequnceLast3Nums[i]} ");
                }
            }
            Console.WriteLine();
        }
    }
}