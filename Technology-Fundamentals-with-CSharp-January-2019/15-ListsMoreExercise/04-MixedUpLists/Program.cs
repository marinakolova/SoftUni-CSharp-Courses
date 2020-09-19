using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            var remainingNumbers = new List<int>();

            if (firstList.Count > secondList.Count)
            {
                remainingNumbers.Add(firstList[firstList.Count - 1]);
                remainingNumbers.Add(firstList[firstList.Count - 2]);
                firstList.RemoveAt(firstList.Count - 1);
                firstList.RemoveAt(firstList.Count - 1);
            }
            else
            {
                remainingNumbers.Add(secondList[0]);
                remainingNumbers.Add(secondList[1]);
                secondList.RemoveAt(0);
                secondList.RemoveAt(0);
            }

            var finalList = firstList.Concat(secondList).ToList();

            var finalListToPrint = new List<int>();

            int biggerNum = 0;
            int smallerNum = 0;

            if (remainingNumbers[0] > remainingNumbers[1])
            {
                biggerNum = remainingNumbers[0];
                smallerNum = remainingNumbers[1];
            }
            else
            {
                biggerNum = remainingNumbers[1];
                smallerNum = remainingNumbers[0];
            }

            foreach (var num in finalList)
            {
                if (num < biggerNum && num > smallerNum)
                {
                    finalListToPrint.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", finalListToPrint.OrderBy(x => x)));
        }
    }
}
