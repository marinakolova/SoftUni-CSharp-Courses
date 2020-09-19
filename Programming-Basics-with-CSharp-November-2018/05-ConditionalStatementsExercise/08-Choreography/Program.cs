using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double stepsPerDay1 = steps / days;
            double stepsPerDayPercent = stepsPerDay1 / steps * 100;
            double stepsPerDay = Math.Ceiling(stepsPerDayPercent);
            double stepsPerDancer = stepsPerDay / dancers;

            if (stepsPerDay <= 13)
                Console.WriteLine($"Yes, they will succeed in that goal! {stepsPerDancer:F2}%.");
            else if (stepsPerDay > 13)
                Console.WriteLine($"No, they will not succeed in that goal! Required {stepsPerDancer:F2}% steps to be learned per day.");
        }
    }
}
