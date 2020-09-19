using System;

namespace _02_CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var sum = 0;

            if (input[0].Length < input[1].Length)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    sum += input[0][i] * input[1][i];
                }

                for (int i = input[0].Length; i < input[1].Length; i++)
                {
                    sum += input[1][i];
                }
            }

            else if (input[1].Length < input[0].Length)
            {
                for (int i = 0; i < input[1].Length; i++)
                {
                    sum += input[1][i] * input[0][i];
                }

                for (int i = input[1].Length; i < input[0].Length; i++)
                {
                    sum += input[0][i];
                }
            }

            else if (input[0].Length == input[1].Length)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    sum += input[1][i] * input[0][i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
