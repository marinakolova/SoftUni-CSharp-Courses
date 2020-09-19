using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_WeddingDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double balloonsPrice = 0.1;
            double flowersPrice = 1.5;
            double candlesPrice = 0.5;
            double ribbonPrice = 2;

            double budget = double.Parse(Console.ReadLine());

            double priceToPay = 0;
            double moneyLeft = 0;
            int ballonsCount = 0;
            int flowersCount = 0;
            int candlesCount = 0;
            int ribbonMeters = 0;

            string command = Console.ReadLine();

            while (!(command == "stop"))
            {
                string typeOfDecoration = command;
                command = Console.ReadLine();
                int countOfDecoration = int.Parse(command);

                if (typeOfDecoration == "balloons")
                {
                    priceToPay += countOfDecoration * balloonsPrice;
                    ballonsCount += countOfDecoration;
                }

                else if (typeOfDecoration == "flowers")
                {
                    priceToPay += countOfDecoration * flowersPrice;
                    flowersCount += countOfDecoration;
                }

                else if (typeOfDecoration == "candles")
                {
                    priceToPay += countOfDecoration * candlesPrice;
                    candlesCount += countOfDecoration;
                }

                else if (typeOfDecoration == "ribbon")
                {
                    priceToPay += countOfDecoration * ribbonPrice;
                    ribbonMeters += countOfDecoration;
                }

                moneyLeft = budget - priceToPay;

                if (moneyLeft <= 0)
                {
                    Console.WriteLine($"All money is spent!");
                    Console.WriteLine($"Purchased decoration is {ballonsCount} balloons, {ribbonMeters} m ribbon, {flowersCount} flowers and {candlesCount} candles.");
                    return;
                }

                else
                command = Console.ReadLine();
            }

            moneyLeft = budget - priceToPay;

            Console.WriteLine($"Spend money: {priceToPay:F2}");
            Console.WriteLine($"Money left: {moneyLeft:F2}");
            Console.WriteLine($"Purchased decoration is {ballonsCount} balloons, {ribbonMeters} m ribbon, {flowersCount} flowers and {candlesCount} candles.");

        }
    }
}
