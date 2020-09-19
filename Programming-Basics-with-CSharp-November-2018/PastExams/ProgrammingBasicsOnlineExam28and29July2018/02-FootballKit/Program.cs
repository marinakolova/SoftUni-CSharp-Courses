using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double sumForReward = double.Parse(Console.ReadLine());

            double shortsPrice = tshirtPrice * 0.75;
            double socksPrice = shortsPrice * 0.20;
            double shoesPrice = 2 * (tshirtPrice + shortsPrice);

            double totalPrice = tshirtPrice + shortsPrice + socksPrice + shoesPrice;
            double totalPriceWithDiscount = totalPrice - 0.15 * totalPrice;

            double moneyNotEnough = sumForReward - totalPriceWithDiscount;

            if (totalPriceWithDiscount >= sumForReward)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalPriceWithDiscount:F2} lv.");
            }

            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {moneyNotEnough:F2} lv. more.");
            }
        }
    }
}
