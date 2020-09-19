using System;
using System.Linq;

namespace _03_RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                            .Split()
                            .Select(double.Parse)
                            .ToArray();

            int[] roundedNums = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                roundedNums[i] = (int)Math.Round(nums[i],
                                    MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i] + " => " + roundedNums[i]);
            }
        }
    }
}
