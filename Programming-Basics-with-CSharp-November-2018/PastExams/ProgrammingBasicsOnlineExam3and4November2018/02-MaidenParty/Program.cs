using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_MaidenParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double partyPrice = double.Parse(Console.ReadLine());
            double loveMessagesCount = double.Parse(Console.ReadLine());
            double waxRosesCount = double.Parse(Console.ReadLine());
            double keyholdersCount = double.Parse(Console.ReadLine());
            double caricaturesCount = double.Parse(Console.ReadLine());
            double luckySurpriseCount = double.Parse(Console.ReadLine());

            double totalIncome = loveMessagesCount * 0.60 + waxRosesCount * 7.2 + keyholdersCount * 3.60 + caricaturesCount * 18.20 + luckySurpriseCount * 22;
            double totalCount = loveMessagesCount + waxRosesCount + keyholdersCount + caricaturesCount + luckySurpriseCount;

            double totalIncomeWithDiscount = 0;

            if (totalCount >= 25)
            {
                totalIncomeWithDiscount = totalIncome - 0.35 * totalIncome;
            }

            else if (totalCount <= 24)
            {
                totalIncomeWithDiscount = totalIncome;
            }

            double hostingExpense = 0.10 * totalIncomeWithDiscount;

            double profit = totalIncomeWithDiscount - hostingExpense;

            double moneyLeft = profit - partyPrice;
            double moneyNeeded = partyPrice - profit;

            if (profit >= partyPrice)
            {
                Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
            }

            else if (profit < partyPrice)
            {
                Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
            }
        }
    }
}
