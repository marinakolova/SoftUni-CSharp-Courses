using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPriceMayOct = 50;
            double apartmentPriceMayOct = 65;
            double studioPriceJuneSept = 75.20;
            double apartmentPriceJuneSept = 68.70;
            double studioPriceJulyAug = 76;
            double apartmentPriceJulyAug = 77;

            double totalStudioPrice = 0;
            double totalApartmentPrice = 0;

            if (month == "May" || month == "October")
            {
                if (nights <= 7)
                {
                    totalStudioPrice = studioPriceMayOct * nights;
                    totalApartmentPrice = apartmentPriceMayOct * nights;
                }

                else if (nights > 7 && nights <= 14)
                {
                    totalStudioPrice = studioPriceMayOct * nights - 0.05 * (studioPriceMayOct * nights);
                    totalApartmentPrice = apartmentPriceMayOct * nights;
                }

                else if (nights > 14)
                {
                    totalStudioPrice = studioPriceMayOct * nights - 0.30 * (studioPriceMayOct * nights);
                    totalApartmentPrice = apartmentPriceMayOct * nights - 0.10 * (apartmentPriceMayOct * nights);
                }
            }

            else if (month == "June" || month == "September")
            {
                if (nights <= 14)
                {
                    totalStudioPrice = studioPriceJuneSept * nights;
                    totalApartmentPrice = apartmentPriceJuneSept * nights;
                }

                else if (nights > 14)
                {
                    totalStudioPrice = studioPriceJuneSept * nights - 0.20 * (studioPriceJuneSept * nights);
                    totalApartmentPrice = apartmentPriceJuneSept * nights - 0.10 * (apartmentPriceJuneSept * nights);
                }
            }

            else if (month == "July" || month == "August")
            {
                totalStudioPrice = studioPriceJulyAug * nights;

                if (nights <= 14)
                    totalApartmentPrice = apartmentPriceJulyAug * nights;
                else if (nights > 14)
                    totalApartmentPrice = apartmentPriceJulyAug * nights - 0.10 * (apartmentPriceJulyAug * nights);
            }

            Console.WriteLine($"Apartment: {totalApartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {totalStudioPrice:F2} lv.");
        }
    }
}
