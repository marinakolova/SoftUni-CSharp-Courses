using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeFor1Meter = double.Parse(Console.ReadLine());

            double totalTime = meters * timeFor1Meter;
            double metersForDelay = meters / 15;
            double metersForDelayRounded = Math.Truncate(metersForDelay);
            double delay = metersForDelayRounded * 12.5;

            double totalTimeWithDelay = totalTime + delay;

            double timeNeeded = totalTimeWithDelay - record;

            if (timeNeeded < 0)
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTimeWithDelay:F2} seconds.");
            else
                Console.WriteLine($"No, he failed! He was {timeNeeded:F2} seconds slower.");

        }
    }
}
