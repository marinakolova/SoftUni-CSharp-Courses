using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WeddingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double waterLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double champagneLiters = double.Parse(Console.ReadLine());
            double whiskeyLiters = double.Parse(Console.ReadLine());

            double champagnePrice = whiskeyPrice * 0.5;
            double winePrice = champagnePrice * 0.4;
            double waterPrice = champagnePrice * 0.1;
            double champagneValue = champagneLiters * champagnePrice;
            double wineValue = wineLiters * winePrice;
            double waterValue = waterLiters * waterPrice;
            double whiskeyValue = whiskeyLiters * whiskeyPrice;
            double totalValue = champagneValue + wineValue + waterValue + whiskeyValue;

            Console.WriteLine($"{totalValue:F2}");
        }
    }
}
