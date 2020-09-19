using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_WeddingInvestment
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractYears = Console.ReadLine();
            string contractType = Console.ReadLine();
            string desert = Console.ReadLine();
            int monthsCount = int.Parse(Console.ReadLine());

            double contractPrice = 0;

            if (contractYears == "one")
            {
                if (contractType == "Small")
                {
                    contractPrice = 9.98;
                }

                else if (contractType == "Middle")
                {
                    contractPrice = 18.99;
                }

                else if (contractType == "Large")
                {
                    contractPrice = 25.98;
                }

                else if (contractType == "ExtraLarge")
                {
                    contractPrice = 35.99;
                }
            }

            else if (contractYears == "two")
            {
                if (contractType == "Small")
                {
                    contractPrice = 8.58;
                }

                else if (contractType == "Middle")
                {
                    contractPrice = 17.09;
                }

                else if (contractType == "Large")
                {
                    contractPrice = 23.59;
                }

                else if (contractType == "ExtraLarge")
                {
                    contractPrice = 31.79;
                }
            }

            double desertPrice = 0;

            if (contractPrice <= 10.00)
            {
                desertPrice = 5.50;
            }

            else if (contractPrice <= 30.00)
            {
                desertPrice = 4.35;
            }

            else if (contractPrice > 30.00)
            {
                desertPrice = 3.85;
            }

            double totalSum = 0;

            if (desert == "yes")
            {
                totalSum = contractPrice + desertPrice;
            }

            else if (desert == "no")
            {
                totalSum = contractPrice;
            }

            double totalSumWithDiscount = 0;

            if (contractYears == "two")
            {
                totalSumWithDiscount = totalSum - 0.0375 * totalSum;
            }

            else if (contractYears == "one")
            {
                totalSumWithDiscount = totalSum;
            }

            double PriceToPay = totalSumWithDiscount * monthsCount;

            Console.WriteLine($"{PriceToPay:F2} lv.");
        }
    }
}
