using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> returnMinNum = x => x.Min();

            Console.WriteLine(returnMinNum(input));
        }
    }
}
