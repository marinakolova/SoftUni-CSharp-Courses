using System;

namespace _05_MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            FindMultiplicationSign(num1, num2, num3);
        }

        private static void FindMultiplicationSign(int num1, int num2, int num3)
        {
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }

            else if (num1 < 0 || num2 < 0 || num3 < 0)
            {
                if ((num1 < 0 && num2 < 0 && num3 <0) 
                    || (num1 < 0 && num2 > 0 && num3 > 0)
                    || (num1 > 0 && num2 < 0 && num3 > 0)
                    || (num1 > 0 && num2 > 0 && num3 < 0))
                {
                    Console.WriteLine("negative");
                }
                else
                {
                    Console.WriteLine("positive");
                }
            }

            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
