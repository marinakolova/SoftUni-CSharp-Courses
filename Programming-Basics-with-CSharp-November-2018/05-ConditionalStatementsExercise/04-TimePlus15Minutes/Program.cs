using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());

            int mins2 = mins + 15;
            int hours2 = 0;
            
            int mins3 = 0;
            int hours3 = 0;

            if (mins2 >= 60)
            {
                hours2 = hours + 1;
                mins3 = mins2 - 60;
            }

            else if (mins2 < 60)
            {
                hours2 = hours;
                mins3 = mins2;
            }

            if (hours2 > 23)
                hours3 = 0;
            else if (hours2 <= 23)
                hours3 = hours2;

            string hoursWithLeadingZero = hours3.ToString("D1");
            string minsWithLeadingZero = mins3.ToString("D2");

            Console.WriteLine($"{hoursWithLeadingZero}:{minsWithLeadingZero}");
        }
    }
}
