using System;

namespace _04_PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintTriangle(num);
            PrintTriangleBottom(num - 1);
        }

        static void PrintTriangle(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintLineOfNums(1, row);
            }
        }

        static void PrintTriangleBottom(int n)
        {
            for (int row = n; row >= 1; row--)
            {
                PrintLineOfNums(1, row);
            }
        }

        static void PrintLineOfNums(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
