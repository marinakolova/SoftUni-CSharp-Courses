using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChristmasSweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double baklavaPrice = double.Parse(Console.ReadLine());
            double muffinPrice = double.Parse(Console.ReadLine());

            double shtolenKg = double.Parse(Console.ReadLine());
            double bonboniKg = double.Parse(Console.ReadLine());
            double biskvitiKg = double.Parse(Console.ReadLine());

            double shtolenPrice = baklavaPrice + 0.60 * baklavaPrice;
            double bonboniPrice = muffinPrice + 0.80 * muffinPrice;
            double biskvitiPrice = 7.50;

            double moneySpend = shtolenKg * shtolenPrice + bonboniKg * bonboniPrice + biskvitiKg * biskvitiPrice;

            Console.WriteLine($"{moneySpend:F2}");
        }
    }
}
