using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WeddingParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int mealsPrice = guestsCount * 20;

            int moneyLeft = budget - mealsPrice;
            int moneyNeeded = mealsPrice - budget;

            double moneyForFireWorks = moneyLeft * 0.40;
            double moneyForCharity = moneyLeft - moneyForFireWorks;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! {moneyForFireWorks:F0} lv are for fireworks and {moneyForCharity:F0} lv are for donation.");
            }

            else if (moneyLeft < 0)
            {
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {moneyNeeded} lv more.");
            }
        }
    }
}
