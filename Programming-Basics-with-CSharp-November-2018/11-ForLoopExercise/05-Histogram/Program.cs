using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1count = 0;
            int p2count = 0;
            int p3count = 0;
            int p4count = 0;
            int p5count = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                    p1count++;
                else if (num >= 200 && num < 400)
                    p2count++;
                else if (num >= 400 && num < 600)
                    p3count++;
                else if (num >= 600 && num < 800)
                    p4count++;
                else if (num >= 800)
                    p5count++;
            }

            double p1 = (double)p1count / n * 100;
            double p2 = (double)p2count / n * 100;
            double p3 = (double)p3count / n * 100;
            double p4 = (double)p4count / n * 100;
            double p5 = (double)p5count / n * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
