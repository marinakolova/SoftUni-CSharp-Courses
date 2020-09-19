using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_WeddingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            int presentsCount = int.Parse(Console.ReadLine());

            int categoryA = 0;
            int categoryB = 0;
            int categoryV = 0;
            int categoryG = 0;

            for (int i = 1; i <= presentsCount; i++)
            {
                string category = Console.ReadLine();

                switch (category)
                {
                    case "A": categoryA++; break;
                    case "B": categoryB++; break;
                    case "V": categoryV++; break;
                    case "G": categoryG++; break;
                }
            }

            double categoryApercentage = (double) categoryA / presentsCount * 100;
            double categoryBpercentage = (double) categoryB / presentsCount * 100;
            double categoryVpercentage = (double) categoryV / presentsCount * 100;
            double categoryGpercentage = (double) categoryG / presentsCount * 100;
            double guestsWithPresentsPercentage = (double) presentsCount / guestsCount * 100;

            Console.WriteLine($"{categoryApercentage:F2}%");
            Console.WriteLine($"{categoryBpercentage:F2}%");
            Console.WriteLine($"{categoryVpercentage:F2}%");
            Console.WriteLine($"{categoryGpercentage:F2}%");
            Console.WriteLine($"{guestsWithPresentsPercentage:F2}%");
        }
    }
}
