using System;

namespace _04_RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i <= n; i++)
            {
                string result = "true";

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        result = "false";
                        break;
                    }
                }

                Console.WriteLine($"{i} -> {result}");
            }

        }
    }
}
