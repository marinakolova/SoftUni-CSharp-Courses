using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectorsCount = int.Parse(Console.ReadLine());
            int stadiumCapacity = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double sectorIncome = (stadiumCapacity * ticketPrice) / sectorsCount;
            double totalIncome = sectorIncome * sectorsCount;

            double moneyForCharity = (totalIncome - (sectorIncome * 0.75)) / 8;

            Console.WriteLine($"Total income - {totalIncome:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
        }
    }
}
