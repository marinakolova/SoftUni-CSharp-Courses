using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Regex namePattern = new Regex(@"@(?<name>[\S\s]*?)\|");
            Regex agePattern = new Regex(@"#(?<age>[\S\s]*?)\*");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (namePattern.IsMatch(input) && agePattern.IsMatch(input))
                {
                    Console.WriteLine($"{namePattern.Match(input).Groups["name"].ToString()} is {agePattern.Match(input).Groups["age"].ToString()} years old.");
                }
            }
        }
    }
}