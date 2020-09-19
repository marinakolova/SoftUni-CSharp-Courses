using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                if (command == "end")
                {
                    break;
                }

                var partsOfCommand = command.Split().ToArray();

                if (partsOfCommand[0] == "add")
                {
                    stack.Push(int.Parse(partsOfCommand[1]));
                    stack.Push(int.Parse(partsOfCommand[2]));
                }
                else if (partsOfCommand[0] == "remove")
                {
                    int numsToRemove = int.Parse(partsOfCommand[1]);

                    if (stack.Count >= numsToRemove)
                    {
                        for (int i = 0; i <= numsToRemove - 1; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
