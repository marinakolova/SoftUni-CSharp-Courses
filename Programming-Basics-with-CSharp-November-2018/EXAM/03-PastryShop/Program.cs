using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PastryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double cakePriceBefore15 = 24;
            double cakePriceAfter15 = 28.70;
            double soufflePriceBefore15 = 6.66;
            double soufflePriceAfter15 = 9.80;
            double baklavaPriceBefore15 = 12.60;
            double baklavaPriceAfter15 = 16.98;

            string type = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            double price = 0;
            double priceWithDiscountForSum = 0;
            double priceWithDiscountForDate = 0;

            if (type == "Cake")
            {
                if (day <= 15)
                {
                    price = cakePriceBefore15 * count;
                }

                else if (day > 15)
                {
                    price = cakePriceAfter15 * count;
                }
            }

            if (type == "Souffle")
            {
                if (day <= 15)
                {
                    price = soufflePriceBefore15 * count;
                }

                else if (day > 15)
                {
                    price = soufflePriceAfter15 * count;
                }
            }

            if (type == "Baklava")
            {
                if (day <= 15)
                {
                    price = baklavaPriceBefore15 * count;
                }

                else if (day > 15)
                {
                    price = baklavaPriceAfter15 * count;
                }
            }

            if (day <= 22 && price >= 100 && price <= 200)
            {
                priceWithDiscountForSum = price - 0.15 * price;
            }

            else if (day <= 22 && price > 200)
            {
                priceWithDiscountForSum = price - 0.25 * price;
            }

            else
            {
                priceWithDiscountForSum = price;
            }

            if (day <= 15)
            {
                priceWithDiscountForDate = priceWithDiscountForSum - 0.10 * priceWithDiscountForSum;
            }

            else
            {
                priceWithDiscountForDate = priceWithDiscountForSum;
            }

            Console.WriteLine($"{priceWithDiscountForDate:F2}");
        }
    }
}
