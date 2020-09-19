using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FamilyHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthsCount = int.Parse(Console.ReadLine());

            double electricity = 0;
            double water = 0;
            double internet = 0;
            double other = 0;

            for (int i = 1; i <= monthsCount; i++)
            {
                double electricityBill = double.Parse(Console.ReadLine());
                electricity += electricityBill;
                double waterBill = 20;
                water += waterBill;
                double internetBill = 15;
                internet += internetBill;
                double otherBill = 1.2 * (electricityBill + waterBill + internetBill);
                other += otherBill;
            }

            double average = (electricity + water + internet + other) / monthsCount;

            Console.WriteLine($"Electricity: {electricity:F2} lv");
            Console.WriteLine($"Water: {water:F2} lv");
            Console.WriteLine($"Internet: {internet:F2} lv");
            Console.WriteLine($"Other: {other:F2} lv");
            Console.WriteLine($"Average: {average:F2} lv");
        }
    }
}
