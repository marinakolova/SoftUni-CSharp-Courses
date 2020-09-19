using System;

namespace _08_MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());
            double result = RaiseToPower(num, pow);
            Console.WriteLine(result);
        }

        private static double RaiseToPower(double num, double pow)
        {
            return Math.Pow(num, pow);           
        }
    }
}
