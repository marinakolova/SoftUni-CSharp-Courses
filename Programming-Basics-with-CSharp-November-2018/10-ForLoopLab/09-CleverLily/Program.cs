using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int toysCount = 0;
            int moneyGiven = 0;
            int moneySaved = 0;

            if (age % 2 == 0)
            {
                for (int i = 0; i < age / 2; i++)
                {
                    toysCount++;
                    moneyGiven +=10;
                    moneySaved = moneySaved + moneyGiven - 1;
                }
            }

            else
            {
                for (int i = 0; i < age / 2; i++)
                {
                    toysCount++;
                    moneyGiven += 10;
                    moneySaved = moneySaved + moneyGiven - 1;
                }
                toysCount++;
            }

            int moneyFromToys = toysCount * toyPrice;
            int money = moneySaved + moneyFromToys;

            double moneyLeft = money - price;
            double moneyNeeded = price - money;

            if (price <= money)
            {
                Console.WriteLine($"Yes! {moneyLeft:F2}");
            }

            else
            {
                Console.WriteLine($"No! {moneyNeeded:F2}");
            }
        }
    }
}
