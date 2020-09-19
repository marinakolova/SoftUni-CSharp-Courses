using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                var num1 = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var num2 = int.Parse(stack.Pop());
                var result = 0;

                if (operation == "+")
                {
                    result = num1 + num2;
                }
                else if (operation == "-")
                {
                    result = num1 - num2;
                }

                stack.Push($"{result}");
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
