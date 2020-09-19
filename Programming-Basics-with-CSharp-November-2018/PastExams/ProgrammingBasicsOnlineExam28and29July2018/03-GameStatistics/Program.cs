using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_GameStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int mins = int.Parse(Console.ReadLine());
            string player = Console.ReadLine();

            if (mins == 0)
                Console.WriteLine("Match has just began!");
            else if (mins < 45)
                Console.WriteLine("First half time.");
            else if (mins >= 45)
                Console.WriteLine("Second half time.");

            if (mins >= 1 && mins <= 10)
            {
                Console.WriteLine($"{player} missed a penalty.");

                if (mins % 2 == 0)
                    Console.WriteLine($"{player} was injured after the penalty.");
            }

            else if (mins > 10 && mins <= 35)
            {
                Console.WriteLine($"{player} received yellow card.");

                if (mins % 2 != 0)
                    Console.WriteLine($"{player} got another yellow card.");
            }

            else if (mins > 35 && mins < 45)
                Console.WriteLine($"{player} SCORED A GOAL !!!");

            else if (mins > 45 && mins <= 55)
            {
                Console.WriteLine($"{player} got a freekick.");

                if (mins % 2 == 0)
                    Console.WriteLine($"{player} missed the freekick.");
            }

            else if (mins > 55 && mins <= 80)
            {
                Console.WriteLine($"{player} missed a shot from corner.");

                if (mins % 2 != 0)
                    Console.WriteLine($"{player} has been changed with another player.");
            }

            else if (mins > 80 && mins <= 90)
                Console.WriteLine($"{player} SCORED A GOAL FROM PENALTY !!!");

        }
    }
}
