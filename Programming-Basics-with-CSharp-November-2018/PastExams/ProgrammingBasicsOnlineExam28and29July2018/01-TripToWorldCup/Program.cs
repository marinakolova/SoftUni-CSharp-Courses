using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double planeTicketPrice = double.Parse(Console.ReadLine());
            double planeTicketPriceBack = double.Parse(Console.ReadLine());
            double gameTicketPrice = double.Parse(Console.ReadLine());
            double gamesCount = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double totalPlaneTicketsPrice = 6 * (planeTicketPrice + planeTicketPriceBack);
            double discountInPercentage = discount / 100;
            double totalPlaneTicketsPriceWithDiscount = totalPlaneTicketsPrice - discountInPercentage * totalPlaneTicketsPrice;
            double totalGamesTicketsPrice = 6 * ( gameTicketPrice * gamesCount );

            double totalSumToPay = totalPlaneTicketsPriceWithDiscount + totalGamesTicketsPrice;
            double sumPerPerson = totalSumToPay / 6;

            Console.WriteLine($"Total sum: {totalSumToPay:F2} lv.");
            Console.WriteLine($"Each friend has to pay {sumPerPerson:F2} lv.");
        }
    }
}
