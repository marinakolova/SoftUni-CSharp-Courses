using System;
using System.Linq;

namespace _02_CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            string[] firstArr = firstInput.Split().ToArray();
            string[] secondArr = secondInput.Split().ToArray();

            string[] commonElements = new string[firstArr.Length];
            int commonElementsIndex = 0;

            for (int i = 0; i < secondArr.Length; i++)
            {
                for (int j = 0; j < firstArr.Length; j++)
                {
                    if (secondArr[i] == firstArr[j])
                    {
                        commonElements[commonElementsIndex] = firstArr[j];
                        commonElementsIndex++;
                    }
                }
            }

            foreach (var element in commonElements)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }
    }
}
