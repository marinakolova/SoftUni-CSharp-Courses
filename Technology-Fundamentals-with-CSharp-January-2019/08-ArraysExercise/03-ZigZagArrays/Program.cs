using System;
using System.Linq;

namespace _03_ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] firstLineOutput = new string[n];
            string[] secondLineOutput = new string[n];

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                if (i % 2 != 0)
                {
                    firstLineOutput[i - 1] = input[0];
                    secondLineOutput[i - 1] = input[1];
                }

                else
                {
                    firstLineOutput[i - 1] = input[1];
                    secondLineOutput[i - 1] = input[0];
                }
            }

            foreach (var num in firstLineOutput)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();

            foreach (var numm in secondLineOutput)
            {
                Console.Write(numm + " ");
            }

            Console.WriteLine();
        }
    }
}
