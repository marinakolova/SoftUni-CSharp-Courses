using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double bonus1 = 5;
            double bonus2 = 0.20 * num;
            double bonus3 = 0.10 * num;

            double bonus4 = 1;
            double bonus5 = 2;

            double result = 0;

            if (num <= 100)
                result = num + bonus1;
            else if (num > 100 && num <= 999)
                result = num + bonus2;
            else if (num > 1000)
                result = num + bonus3;

            double result2 = 0;

            if (num % 2 == 0)
                result2 = result + bonus4;
            else if (num % 10 == 5)
                result2 = result + bonus5;
            else
                result2 = result;

            Console.WriteLine(result2 - num);
            Console.WriteLine(result2);

        }
    }
}
