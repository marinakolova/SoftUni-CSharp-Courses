using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._ThreeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double brother1Time = double.Parse(Console.ReadLine());
            double brother2Time = double.Parse(Console.ReadLine());
            double brother3Time = double.Parse(Console.ReadLine());
            double fatherTime = double.Parse(Console.ReadLine());

            double cleaningTime = 1 / (1/brother1Time + 1/brother2Time + 1/brother3Time);
            double cleaningTimeWithRest = cleaningTime + 0.15 * cleaningTime;

            double timeLeft = fatherTime - cleaningTimeWithRest;
            double timeNeeded = cleaningTimeWithRest - fatherTime;

            Console.WriteLine($"Cleaning time: {cleaningTimeWithRest:F2}");

            if (timeLeft > 0)
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Truncate(timeLeft)} hours.");
            else
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeNeeded)} hours.");
        }
    }
}
