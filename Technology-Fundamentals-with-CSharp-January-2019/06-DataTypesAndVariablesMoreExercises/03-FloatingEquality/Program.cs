using System;

namespace _03_FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal numOne = decimal.Parse(Console.ReadLine());
            decimal numTwo = decimal.Parse(Console.ReadLine());
            decimal eps = 0.000001M;
            decimal diff = 0;
            bool isEqual = true;

            if (numOne >= numTwo)
            {
                diff = numOne - numTwo;

                if (diff >= eps)
                {
                    isEqual = false;
                }
            }

            if (numTwo > numOne)
            {
                diff = numTwo - numOne;

                if (diff >= eps)
                {
                    isEqual = false;
                }
            }

            Console.WriteLine(isEqual);
        }
    }
}
