using System;
using System.Numerics;

namespace _05_MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNum = BigInteger.Parse(Console.ReadLine());

            BigInteger product = firstNum * secondNum;

            Console.WriteLine(product);
        }
    }
}
