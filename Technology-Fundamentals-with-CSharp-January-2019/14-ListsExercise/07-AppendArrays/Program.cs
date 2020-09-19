using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfNumsAsStrings = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
            string numsAsString = "";
            for (int i = 0; i < listOfNumsAsStrings.Count; i++)
            {
                numsAsString += listOfNumsAsStrings[i];
                numsAsString += " ";
            }

            List<int> nums = numsAsString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
