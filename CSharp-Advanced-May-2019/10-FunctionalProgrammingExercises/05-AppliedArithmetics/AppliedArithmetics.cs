using System;
using System.Linq;

namespace _05_AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        input = input.Select(x => x += 1).ToList();
                        break;

                    case "multiply":
                        input = input.Select(x => x *= 2).ToList();
                        break;

                    case "subtract":
                        input = input.Select(x => x -= 1).ToList();
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", input));
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
