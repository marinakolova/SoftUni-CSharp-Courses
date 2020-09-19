using System;
using System.Text.RegularExpressions;

namespace _06_MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var matches = Regex.Matches(text, @"\b([A-Z][a-z]{1,}) ([A-Z][a-z]{1,})");

            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
