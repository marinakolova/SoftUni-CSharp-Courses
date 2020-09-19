using System;
using System.Linq;

namespace _06_EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;
            int conditionIndex = -1;

            for (int i = 0; i < input.Length; i++)
            {
                for (int leftNum = 0; leftNum <= i; leftNum++)
                {
                    leftSum += input[leftNum];
                }

                if (leftSum != 0)
                {
                    leftSum -= input[i];
                }

                for (int rightNum = i + 1; rightNum < input.Length; rightNum++)
                {
                    rightSum += input[rightNum];
                }

                if (leftSum == rightSum)
                {
                    conditionIndex = i;
                }

                leftSum = 0;
                rightSum = 0;
            }

            if (conditionIndex >= 0)
            {
                Console.WriteLine(conditionIndex);
            }

            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
