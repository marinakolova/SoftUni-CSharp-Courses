using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nums[0];
            int s = nums[1];
            int x = nums[2];

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            foreach (var num in numbers)
            {
                stack.Push(num);
            }

            for (int i = 0; i < s; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
