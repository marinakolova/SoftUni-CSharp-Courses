using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WeddingHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallLength = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double barSide = double.Parse(Console.ReadLine());

            double hallSize = hallLength * hallWidth;
            double barSize = barSide * barSide;
            double dancingSize = hallSize * 0.19;
            double freeSpace = hallSize - barSize - dancingSize;
            double guestsCount = freeSpace / 3.2;

            Console.WriteLine($"{Math.Ceiling(guestsCount)}");
        }
    }
}
