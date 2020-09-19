using System;
using System.Text.RegularExpressions;

namespace _08_MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            var pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            var matches = Regex.Matches(line, pattern);

            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
