using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double games = (48 - h) * 3.0 / 4 + h + p * 2.0 / 3;
            double games1 = 0;

            if (year == "leap")
                games1 = games + 0.15 * games;
            else if (year == "normal")
                games1 = games;

            Console.WriteLine(Math.Truncate(games1));
        }
    }
}
