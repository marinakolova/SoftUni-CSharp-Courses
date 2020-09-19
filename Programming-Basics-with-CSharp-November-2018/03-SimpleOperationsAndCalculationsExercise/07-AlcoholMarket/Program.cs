using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double whiskeyLiters = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskeyPrice / 2;
            double winePrice = rakiaPrice - (0.4 * rakiaPrice);
            double beerPrice = rakiaPrice - (0.8 * rakiaPrice);

            double rakiaValue = rakiaLiters * rakiaPrice;
            double wineValue = wineLiters * winePrice;
            double beerValue = beerLiters * beerPrice;
            double whiskeyValue = whiskeyLiters * whiskeyPrice;
            double totalValue = rakiaValue + wineValue + beerValue + whiskeyValue;

            Console.WriteLine($"{totalValue:F2}");


        }
    }
}
