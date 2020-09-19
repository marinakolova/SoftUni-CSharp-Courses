using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzlePrice = 2.60;
            double talkingDollPrice = 3;
            double teddyBearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2;

            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int talkingDollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            int totalCount = puzzlesCount + talkingDollsCount + teddyBearsCount + minionsCount + trucksCount;

            double totalPrice = puzzlePrice * puzzlesCount + talkingDollPrice * talkingDollsCount + teddyBearPrice * teddyBearsCount + minionPrice * minionsCount + truckPrice * trucksCount;
            double totalPriceWithDiscount = 0;

            if (totalCount < 50)
                totalPriceWithDiscount = totalPrice;
            else if (totalCount >= 50)
                totalPriceWithDiscount = totalPrice - 0.25 * totalPrice;

            double incomeAfterRent = totalPriceWithDiscount - 0.10 * totalPriceWithDiscount;

            double moneyLeft = incomeAfterRent - tripPrice;
            double moneyNeeded = tripPrice - incomeAfterRent;

            if (moneyLeft >= 0)
                Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
            else
                Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
        }
    }
}
