using System;

namespace _4_HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var pricePerDay = decimal.Parse(info[0]);
            var numberOfDays = int.Parse(info[1]);
            var season = info[2];
            var discountType = "";

            if (info.Length > 3)
            {
                discountType = info[3];
            }

            var totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, season, discountType);

            Console.WriteLine($"{totalPrice:F2}");            
        }
    }
}
