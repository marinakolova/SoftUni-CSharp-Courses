using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int count = nums.Count;

            for (int i = 0; i < count / 2; i++)
            {
                nums[i] += nums[count - 1 - i];
                nums.RemoveAt(count - 1 - i);
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
