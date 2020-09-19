using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string accomodation = "";
            double spend = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    accomodation = "Camp";
                    spend = 0.30 * budget;
                }

                else if (season == "winter")
                {
                    accomodation = "Hotel";
                    spend = 0.70 * budget;
                }
            }

            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    accomodation = "Camp";
                    spend = 0.40 * budget;
                }

                else if (season == "winter")
                {
                    accomodation = "Hotel";
                    spend = 0.80 * budget;
                }
            }

            else if (budget > 1000)
            {
                destination = "Europe";
                accomodation = "Hotel";
                spend = 0.90 * budget;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accomodation} - {spend:F2}");
        }
    }
}
