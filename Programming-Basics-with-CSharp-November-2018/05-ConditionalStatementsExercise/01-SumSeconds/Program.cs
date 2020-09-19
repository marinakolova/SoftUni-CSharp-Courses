using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int secs1 = int.Parse(Console.ReadLine());
            int secs2 = int.Parse(Console.ReadLine());
            int secs3 = int.Parse(Console.ReadLine());

            int secsTotal = secs1 + secs2 + secs3;
            string secsWithLeadingZero = secsTotal.ToString("D2");

            int secsTotal1 = secsTotal - 60;
            string secsWithLeadingZero1 = secsTotal1.ToString("D2");

            int secsTotal2 = secsTotal - 120;
            string secsWithLeadingZero2 = secsTotal2.ToString("D2");

            int secsTotal3 = secsTotal - 180;
            string secsWithLeadingZero3 = secsTotal3.ToString("D2");

            if (secsTotal < 59)
                Console.WriteLine($"0:{secsWithLeadingZero}");
            else if (secsTotal >= 60 && secsTotal <= 119)
                Console.WriteLine($"1:{secsWithLeadingZero1}");
            else if (secsTotal >= 120 && secsTotal <= 179)
                Console.WriteLine($"2:{secsWithLeadingZero2}");
            else
                Console.WriteLine($"3:{secsWithLeadingZero3}");
        }
    }
}
