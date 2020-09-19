using System;
using System.Linq;

namespace _07_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int length = 1;
            int maxLength = 1;
            int numWithMaxLength = input[0];

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    length++;
                }

                else
                {
                    if (length > maxLength)
                    {
                        maxLength = length;
                        if (i != 0)
                        {
                            numWithMaxLength = input[i - 1];
                        }
                    }

                    length = 1;
                }
            }

            if (length > maxLength)
            {
                maxLength = length;
                numWithMaxLength = input[input.Length - 1];                
            }

            int[] output = new int[maxLength];

            for (int j  = 0; j < maxLength; j++)
            {
                output[j] = numWithMaxLength;
            }

            foreach (var num in output)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
