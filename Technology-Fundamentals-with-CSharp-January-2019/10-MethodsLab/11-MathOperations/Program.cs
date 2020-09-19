using System;

namespace _11_MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double result = Calculate(a, operation, b);
            Console.WriteLine(Math.Round(result, 2));
        }

        private static double Calculate(int a, char operation, int b)
        {
            double result = 0;

            switch (operation)
            {
                case '/': result = a / b; break;
                case '*': result = a * b; break;
                case '+': result = a + b; break;
                case '-': result = a - b; break;
            }

            return result;
        }
    }
}
