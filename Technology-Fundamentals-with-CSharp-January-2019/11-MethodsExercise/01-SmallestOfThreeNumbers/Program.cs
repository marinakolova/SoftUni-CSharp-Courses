using System;

namespace _01_SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            GetSmallestOfThree(a, b, c);            
        }

        private static void GetSmallestOfThree(int a, int b, int c)
        {
            if (a <= b && a <= c)
            {
                Console.WriteLine(a);
            }
            else if (b <= a && b <= c)
            {
                Console.WriteLine(b);
            }
            else if (c <= a && c <= b)
            {
                Console.WriteLine(c);
            }
        }
    }
}
