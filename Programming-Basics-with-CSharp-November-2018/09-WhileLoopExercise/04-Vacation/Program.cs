using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double moneyBalance = double.Parse(Console.ReadLine());
            int spendTimes = 0;
            int daysCount = 0;

            while (spendTimes < 5 && moneyBalance < tripPrice)
            {
                string action = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                daysCount++;

                if (action == "spend")
                {
                    spendTimes++;

                    if (sum >= moneyBalance)
                        moneyBalance = 0;
                    else 
                        moneyBalance -= sum;
                }

                else if (action == "save")
                {
                    spendTimes = 0;
                    moneyBalance += sum;
                }
            }

            if (spendTimes >= 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{daysCount}");
            }

            else if (moneyBalance >= tripPrice)
            {
                Console.WriteLine($"You saved the money for {daysCount} days.");
            }
        }
    }
}
