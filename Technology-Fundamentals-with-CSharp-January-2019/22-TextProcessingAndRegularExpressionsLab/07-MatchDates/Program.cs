using System;
using System.Text.RegularExpressions;

namespace _06_MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})([.\/-]{1})(?<month>[a-zA-Z]{3})\1(?<year>\d{4})";
            var dates = Regex.Matches(input, pattern);
            foreach (Match item in dates)
            {
                var day = item.Groups["day"].Value;
                var month = item.Groups["month"].Value;
                var year = item.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
