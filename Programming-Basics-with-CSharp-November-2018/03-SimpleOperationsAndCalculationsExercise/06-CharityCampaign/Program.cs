using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakesCount = int.Parse(Console.ReadLine());
            int wafflesCount = int.Parse(Console.ReadLine());
            int pancakesCount = int.Parse(Console.ReadLine());

            double cakesValue = cakesCount * 45;
            double wafflesValue = wafflesCount * 5.80;
            double pancakesValue = pancakesCount * 3.20;
            double ValuePerDay = (cakesValue + wafflesValue + pancakesValue) * bakers;
            double ValueTotal = ValuePerDay * days;
            double ValueForCharity = ValueTotal - ValueTotal / 8;

            Console.WriteLine($"{ValueForCharity:F2}");
        }
    }
}
