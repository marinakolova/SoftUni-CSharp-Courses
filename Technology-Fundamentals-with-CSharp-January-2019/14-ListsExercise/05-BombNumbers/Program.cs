using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombAndPow = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = bombAndPow[0];
            int power = bombAndPow[1];

            while (input.Contains(bomb))
            {
                int indexOfBomb = input.IndexOf(bomb);

                for (int i = 0; i < power; i++)
                {
                    if (indexOfBomb + 1 < input.Count)
                    {
                        input.RemoveAt(indexOfBomb + 1);
                    }
                }

                input.RemoveAt(indexOfBomb);

                for (int i = 0; i < power; i++)
                {
                    if (indexOfBomb - 1 - i >= 0)
                    {
                        input.RemoveAt(indexOfBomb - 1 - i);
                    }                    
                }
            }

            Console.WriteLine(input.Sum());
        }
    }
}
