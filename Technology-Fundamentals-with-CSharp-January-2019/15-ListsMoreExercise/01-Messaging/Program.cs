using System;
using System.Linq;
using System.Text;

namespace _01_Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var text = Console.ReadLine();
            var sb = new StringBuilder();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                var currInt = listOfNumbers[i];
                var sumOfDigits = 0;

                while (currInt > 0)
                {
                    var currDigit = currInt % 10;
                    sumOfDigits += currDigit;
                    currInt = currInt / 10;
                }

                if (sumOfDigits > text.Length)
                {
                    while (sumOfDigits > text.Length)
                    {
                        sumOfDigits -= (text.Length - 1);
                    }

                    sb.Append(text[sumOfDigits - 1]);
                    text = text.Remove((sumOfDigits - 1), 1);
                }

                else
                {
                    sb.Append(text[sumOfDigits]);
                    text = text.Remove(sumOfDigits, 1);
                }                               
            }

            Console.WriteLine(sb);
        }
    }
}
