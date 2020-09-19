using System;
using System.Collections.Generic;
using System.Text;

namespace _4_HotelReservation
{
    public static class PriceCalculator
    {
        public enum Seasons
        {
            Autumn = 1,
            Spring,
            Winter,
            Summer
        }

        public enum Discounts
        {
            VIP = 20,
            SecondVisit = 10,
            None = 0
        }

        public static decimal GetTotalPrice(decimal pricePerDay, int numberOfDays, string season, string discountType)
        {
            decimal totalPrice = pricePerDay * numberOfDays;

            int seasonMultiplicator = (int)System.Enum.Parse(typeof(Seasons), season);

            totalPrice *= seasonMultiplicator;

            if (discountType != "")
            {
                decimal discountRate = (decimal)(int)System.Enum.Parse(typeof(Discounts), discountType);

                totalPrice -= (discountRate / 100) * totalPrice;
            }

            return totalPrice;
        }
    }
}
