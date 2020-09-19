using System;

namespace _01_SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a > b && a > c)
            {
                Console.WriteLine(a);

                if (b > c)
                {
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }

                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(b);
                }
            }

            else if (b > a && b > c)
            {
                Console.WriteLine(b);

                if (a > c)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(c);
                }

                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(a);
                }
            }

            else if (c > a && c > b)
            {
                Console.WriteLine(c);

                if (a > b)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                }

                else
                {
                    Console.WriteLine(b);
                    Console.WriteLine(a);
                }
            }
        }
    }
}
