using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1count = 0;
            int p2count = 0;
            int p3count = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                    p1count++;
                if (num % 3 == 0)
                    p2count++;
                if (num % 4 == 0)
                    p3count++;
            }

            double p1 = (double)p1count / n * 100;
            double p2 = (double)p2count / n * 100;
            double p3 = (double)p3count / n * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
