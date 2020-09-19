using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double transport = 0;

            if (people >= 1 && people <= 4)
                transport = 0.75 * budget;
            else if (people >= 5 && people <= 9)
                transport = 0.60 * budget;
            else if (people >= 10 && people <= 24)
                transport = 0.50 * budget;
            else if (people >= 25 && people <= 49)
                transport = 0.40 * budget;
            else if (people >= 50)
                transport = 0.25 * budget;

            double moneyLeftAfterTransport = budget - transport;
            double tickets = 0;

            if (category == "VIP")
                tickets = 499.99 * people;
            else if (category == "Normal")
                tickets = 249.99 * people;

            double moneyLeft = moneyLeftAfterTransport - tickets;
            double moneyNeeded = tickets - moneyLeftAfterTransport;

            if (moneyLeft >= 0)
                Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
            else if (moneyLeft < 0)
                Console.WriteLine($"Not enough money! You need {moneyNeeded:F2} leva.");
        }
    }
}
