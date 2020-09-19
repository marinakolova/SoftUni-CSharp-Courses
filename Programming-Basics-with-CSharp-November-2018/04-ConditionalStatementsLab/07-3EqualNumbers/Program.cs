using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_3EqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if (num1 == num2)
            {
                if (num2 == num3)
                    Console.WriteLine("yes");
                else
                    Console.WriteLine("no");
            }

            else
                Console.WriteLine("no");
        }
    }
}
