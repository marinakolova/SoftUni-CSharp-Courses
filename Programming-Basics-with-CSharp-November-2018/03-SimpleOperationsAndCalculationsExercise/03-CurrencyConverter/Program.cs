using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();

            double result = 0;

            if (inputCurrency == "BGN")
            {
                if (outputCurrency == "USD")
                {
                    result = money / 1.79549;
                }

                else if (outputCurrency == "EUR")
                {
                    result = money / 1.95583;
                }

                else if (outputCurrency == "GBP")
                {
                    result = money / 2.53405;
                }
            }

            else if (inputCurrency == "USD")
            {
                if (outputCurrency == "BGN")
                {
                    result = money * 1.79549;
                }

                else if (outputCurrency == "EUR")
                {
                    result = money * 1.79549 / 1.95583;
                }

                else if (outputCurrency == "GBP")
                {
                    result = money * 1.79549 / 2.53405;
                }
            }

            else if (inputCurrency == "EUR")
            {
                if (outputCurrency == "BGN")
                {
                    result = money * 1.95583;
                }

                else if (outputCurrency == "USD")
                {
                    result = money * 1.95583 / 1.79549;
                }

                else if (outputCurrency == "GBP")
                {
                    result = money * 1.95583 / 2.53405;
                }
            }

            else if (inputCurrency == "GBP")
            {
                if (outputCurrency == "BGN")
                {
                    result = money * 2.53405;
                }

                else if (outputCurrency == "USD")
                {
                    result = money * 2.53405 / 1.79549;
                }

                else if (outputCurrency == "EUR")
                {
                    result = money * 2.53405 / 1.95583;
                }
            }

            Console.WriteLine($"{result:F2} {outputCurrency}");
        }
    }
}
