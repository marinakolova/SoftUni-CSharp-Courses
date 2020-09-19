using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tablesCount = int.Parse(Console.ReadLine());
            double tablesLength = double.Parse(Console.ReadLine());
            double tablesWidth = double.Parse(Console.ReadLine());

            double coversArea = tablesCount * (tablesLength + 2 * 0.30) * (tablesWidth + 2 * 0.30);
            double squaresArea = tablesCount * (tablesLength / 2) * (tablesLength / 2);

            double priceUSD = coversArea * 7 + squaresArea * 9;
            double priceBGN = priceUSD * 1.85;

            Console.WriteLine($"{priceUSD:F2} USD");
            Console.WriteLine($"{priceBGN:F2} BGN");

        }
    }
}
