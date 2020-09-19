using System;
using System.Linq;

namespace _04_ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            int n = int.Parse(Console.ReadLine()); // num of rotations

            for (int i = 0; i < n; i++)
            {
                string rotatedNum = input[0];

                for (int j = 0; j < input.Length - 1; j++)
                {
                    input[j] = input[j + 1];
                }

                input[input.Length - 1] = rotatedNum;
            }

            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
