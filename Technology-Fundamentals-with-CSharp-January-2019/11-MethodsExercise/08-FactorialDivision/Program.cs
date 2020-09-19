using System;

namespace _08_FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double firstFactorial = GetFactorial(a);
            double secondFactorial = GetFactorial(b);
            double result = firstFactorial / secondFactorial;
            Console.WriteLine($"{result:F2}");
        }

        private static double GetFactorial(int a)
        {
            double factorial = 1;

            for (int i = 2; i <= a; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
