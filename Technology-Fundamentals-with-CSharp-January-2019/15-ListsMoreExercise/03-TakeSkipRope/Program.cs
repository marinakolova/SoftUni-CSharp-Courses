using System;
using System.Collections.Generic;

namespace _03_TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedMessage = Console.ReadLine();

            var numbersList = new List<int>();
            var nonNumbersList = new List<string>();

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (char.IsDigit(encryptedMessage[i]))
                {
                    int digit = int.Parse(encryptedMessage[i].ToString());
                    numbersList.Add(digit);
                }
                else
                {
                    string nonDigit = encryptedMessage[i].ToString();
                    nonNumbersList.Add(nonDigit);
                }
            }

            var takeList = new List<int>();
            var skipList = new List<int>();

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                    skipList.Add(numbersList[i]);
                }
            }

            var decryptedMessage = new List<string>();

            for (int i = 0; i < takeList.Count; i++)
            {
                int takeCount = takeList[i];

                for (int j = 1; j <= takeCount; j++)
                {
                    if (nonNumbersList.Count > 0)
                    {
                        decryptedMessage.Add(nonNumbersList[0]);
                        nonNumbersList.RemoveAt(0);
                    }                    
                }

                int skipCount = skipList[i];

                for (int k = 1; k <= skipCount; k++)
                {
                    if (nonNumbersList.Count > 0)
                    {
                        nonNumbersList.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine(string.Join("", decryptedMessage));
        }
    }
}
