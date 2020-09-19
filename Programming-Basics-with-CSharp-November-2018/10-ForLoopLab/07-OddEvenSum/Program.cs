using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOdd = 0;
            int sumEven = 0;

            if (n % 2 == 0)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    int numOdd = int.Parse(Console.ReadLine());
                    sumOdd += numOdd;
                    int numEven = int.Parse(Console.ReadLine());
                    sumEven += numEven;
                }
            }

            else
            {
                for (int i = 0; i < n / 2; i++)
                {
                    int numOdd = int.Parse(Console.ReadLine());
                    sumOdd += numOdd;
                    int numEven = int.Parse(Console.ReadLine());
                    sumEven += numEven;                    
                }
                int numOddLast = int.Parse(Console.ReadLine());
                sumOdd += numOddLast;
            }

            if (sumOdd == sumEven)
            {
                Console.WriteLine("Ýes");
                Console.WriteLine($"Sum = {sumOdd}");
            }

            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumOdd - sumEven)}");
            }
        }
    }
}
