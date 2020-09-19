using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Honeymoon
{
    class Program
    {
        static void Main(string[] args)
        {
            int CairoNightPrice = 250 * 2;
            int CairoTicketsPrice = 600;
            int ParisNightPrice = 150 * 2;
            int ParisTicketsPrice = 350;
            int LimaNightPrice = 400 * 2;
            int LimaTicketsPrice = 850;
            int NYNightPrice = 300 * 2;
            int NYTicketsPrice = 650;
            int TokyoNightPrice = 350 * 2;
            int TokyoTicketsPrice = 700;

            double budget = double.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            int totalSum = 0;
            double discountSum = 0;

            if (town == "Cairo")
            {
                totalSum = nightsCount * CairoNightPrice + CairoTicketsPrice;

                if (nightsCount <= 4)
                {
                    discountSum = totalSum - 0.03 * totalSum;
                }

                else if (nightsCount <= 9)
                {
                    discountSum = totalSum - 0.05 * totalSum;
                }

                else if (nightsCount <= 24)
                {
                    discountSum = totalSum - 0.10 * totalSum;
                }

                else if (nightsCount <= 49)
                {
                    discountSum = totalSum - 0.17 * totalSum;
                }

                else if (nightsCount >= 50)
                {
                    discountSum = totalSum - 0.30 * totalSum;
                }

            }

            else if (town == "Paris")
            {
                totalSum = nightsCount * ParisNightPrice + ParisTicketsPrice;

                if (nightsCount <= 4)
                {
                    discountSum = totalSum;
                }

                else if (nightsCount <= 9)
                {
                    discountSum = totalSum - 0.07 * totalSum;
                }

                else if (nightsCount <= 24)
                {
                    discountSum = totalSum - 0.12 * totalSum;
                }

                else if (nightsCount <= 49)
                {
                    discountSum = totalSum - 0.22 * totalSum;
                }

                else if (nightsCount >= 50)
                {
                    discountSum = totalSum - 0.30 * totalSum;
                }

            }

            else if (town == "Lima")
            {
                totalSum = nightsCount * LimaNightPrice + LimaTicketsPrice;

                if (nightsCount <= 4)
                {
                    discountSum = totalSum;
                }

                else if (nightsCount <= 9)
                {
                    discountSum = totalSum;
                }

                else if (nightsCount <= 24)
                {
                    discountSum = totalSum;
                }

                else if (nightsCount <= 49)
                {
                    discountSum = totalSum - 0.19 * totalSum;
                }

                else if (nightsCount >= 50)
                {
                    discountSum = totalSum - 0.30 * totalSum;
                }

            }

            else if (town == "New York")
            {
                totalSum = nightsCount * NYNightPrice + NYTicketsPrice;

                if (nightsCount <= 4)
                {
                    discountSum = totalSum - 0.03 * totalSum;
                }

                else if (nightsCount <= 9)
                {
                    discountSum = totalSum - 0.05 * totalSum;
                }

                else if (nightsCount <= 24)
                {
                    discountSum = totalSum - 0.12 * totalSum;
                }

                else if (nightsCount <= 49)
                {
                    discountSum = totalSum - 0.19 * totalSum;
                }

                else if (nightsCount >= 50)
                {
                    discountSum = totalSum - 0.30 * totalSum;
                }

            }

            else if (town == "Tokyo")
            {
                totalSum = nightsCount * TokyoNightPrice + TokyoTicketsPrice;

                if (nightsCount <= 4)
                {
                    discountSum = totalSum;
                }

                else if (nightsCount <= 9)
                {
                    discountSum = totalSum;
                }

                else if (nightsCount <= 24)
                {
                    discountSum = totalSum - 0.12 * totalSum;
                }

                else if (nightsCount <= 49)
                {
                    discountSum = totalSum - 0.17 * totalSum;
                }

                else if (nightsCount >= 50)
                {
                    discountSum = totalSum - 0.30 * totalSum;
                }

            }


            double moneyLeft = budget - discountSum;
            double moneyNeeded = discountSum - budget;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
            }

            else if (moneyLeft < 0)
            {
                Console.WriteLine($"Not enough money! You need {moneyNeeded:F2} leva.");
            }
           
        }
       
    }
}
