using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _11_LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            char currentFirstChar = ' ';
            char currentSecondChar = ' ';
            int firstIndex = 0;
            int secondIndex = 0;
            List<double> finalList = new List<double>();
            string input = Console.ReadLine();
            double currentValue = 0.0;

            char firstChar = ' ';
            char secondChar = ' ';
            string pattern = @"(?<firstLetter>[A-Za-z])(?<number>[\d]+)(?<lastLetter>[A-Za-z])";

            Regex order = new Regex(pattern);

            MatchCollection matches = order.Matches(input);

            foreach (Match match in matches)
            {
                firstChar = Convert.ToChar(match.Groups["firstLetter"].Value);
                secondChar = Convert.ToChar(match.Groups["lastLetter"].Value);

                //Letter before the number
                if (Char.IsUpper(firstChar))
                {
                    currentFirstChar = Convert.ToChar(match.Groups["firstLetter"].Value);
                    firstIndex = char.ToUpper(currentFirstChar) - 64;
                    currentValue = int.Parse(match.Groups["number"].Value);
                    currentValue = currentValue / firstIndex;
                }
                else if (Char.IsLower(firstChar))
                {
                    currentFirstChar = Convert.ToChar(match.Groups["firstLetter"].Value);
                    firstIndex = char.ToUpper(currentFirstChar) - 64;
                    currentValue = int.Parse(match.Groups["number"].Value);
                    currentValue = currentValue * firstIndex;
                }

                //Letter after the number
                if (Char.IsUpper(secondChar))
                {
                    currentSecondChar = Convert.ToChar(match.Groups["lastLetter"].Value);
                    secondIndex = char.ToUpper(currentSecondChar) - 64;
                    currentValue = currentValue - secondIndex;
                }
                else if (Char.IsLower(secondChar))
                {
                    currentSecondChar = Convert.ToChar(match.Groups["lastLetter"].Value);
                    secondIndex = char.ToUpper(currentSecondChar) - 64;
                    currentValue = currentValue + secondIndex;
                }
                finalList.Add(currentValue);
            }
            double finalSum = finalList.Sum();
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}
