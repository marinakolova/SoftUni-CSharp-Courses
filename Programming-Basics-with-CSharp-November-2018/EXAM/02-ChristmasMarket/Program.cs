using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChristmasMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyWanted = double.Parse(Console.ReadLine());
            int fantasyBooks = int.Parse(Console.ReadLine());
            int horrorBooks = int.Parse(Console.ReadLine());
            int romanticBooks = int.Parse(Console.ReadLine());

            double fantasyPrice = 14.90;
            double horrorPrice = 9.80;
            double romanticPrice = 4.30;

            double moneyEarned = fantasyBooks * fantasyPrice + horrorBooks * horrorPrice + romanticBooks * romanticPrice;
            double moneyEarnedWithoutDDS = moneyEarned - 0.20 * moneyEarned;

            if (moneyEarnedWithoutDDS > moneyWanted)
            {
                double moneyOverWanted = moneyEarnedWithoutDDS - moneyWanted;
                double salary = Math.Floor(0.10 * moneyOverWanted);
                double moneyToAdd = moneyOverWanted - salary;
                double charityMoney = moneyWanted + moneyToAdd;

                Console.WriteLine($"{charityMoney:F2} leva donated.");
                Console.WriteLine($"Sellers will receive {salary} leva.");
            }

            else if (moneyEarnedWithoutDDS < moneyWanted)
            {
                double moneyNeeded = moneyWanted - moneyEarnedWithoutDDS;

                Console.WriteLine($"{moneyNeeded:F2} money needed.");
            }
        }
    }
}
