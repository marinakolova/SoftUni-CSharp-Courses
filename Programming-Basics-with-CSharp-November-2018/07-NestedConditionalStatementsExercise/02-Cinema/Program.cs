using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int capacity = r * c;
            double income = 0;

            if (type == "Premiere")
                income = capacity * 12.00;
            else if (type == "Normal")
                income = capacity * 7.50;
            else if (type == "Discount")
                income = capacity * 5.00;

            Console.WriteLine($"{income:F2}");
        }
    }
}
