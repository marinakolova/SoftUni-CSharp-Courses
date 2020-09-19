using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsTotal = 0;
            int mainGoal = 10000;
            string command = Console.ReadLine();

            while (command != "Going home")
            {
                int steps = int.Parse(command);
                stepsTotal += steps;

                if (stepsTotal >= mainGoal)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    return;
                }

                else if (stepsTotal < mainGoal)
                {
                    command = Console.ReadLine();
                }
            }

            int stepsToHome = int.Parse(Console.ReadLine());
            stepsTotal += stepsToHome;

            if (stepsTotal >= mainGoal)
            {
                Console.WriteLine("Goal reached! Good job!");
                return;
            }

            int stepsLeft = mainGoal - stepsTotal;

            Console.WriteLine($"{stepsLeft} more steps to reach goal.");
        }
    }
}
