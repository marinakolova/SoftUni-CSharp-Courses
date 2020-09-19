using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();

                switch (command)
                {
                    case "2":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;

                    case "3":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;

                    case "4":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;

                    default:
                        var commandParts = command.Split().Select(int.Parse).ToArray();
                        stack.Push(commandParts[1]);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
