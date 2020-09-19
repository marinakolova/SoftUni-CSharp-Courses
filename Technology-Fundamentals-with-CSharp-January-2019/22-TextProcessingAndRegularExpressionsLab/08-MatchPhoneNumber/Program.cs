using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08_MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"( ?\+359 2 \d{3} \d{4})|(\+ ?359-2-\d{3}-\d{4})";
            var matches = Regex.Matches(Console.ReadLine(), pattern);
            var listofnumbers = new List<string>();
            foreach (Match match in matches)
            {
                listofnumbers.Add(match.Value.Trim());
            }
            Console.WriteLine(string.Join(", ", listofnumbers));
        }
    }
}
