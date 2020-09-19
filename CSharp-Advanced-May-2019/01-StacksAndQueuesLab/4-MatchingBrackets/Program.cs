using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            var substrings = new List<string>();

            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    var firstIndex = indexes.Pop();
                    var secondIndex = i;
                    var substring = input.Substring(firstIndex, secondIndex - firstIndex + 1);
                    substrings.Add(substring);
                }
            }

            foreach (var substr in substrings)
            {
                Console.WriteLine(substr);
            }
        }
    }
}
