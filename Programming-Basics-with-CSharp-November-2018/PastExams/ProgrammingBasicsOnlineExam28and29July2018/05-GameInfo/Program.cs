using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int gamesPlayed = int.Parse(Console.ReadLine());

            int mins = 0;
            int totalMins = 0;
            int gamesWithPenalties = 0;
            int gamesWithAddTime = 0;

            for (int i = 0; i < gamesPlayed; i++)
            {
                mins = int.Parse(Console.ReadLine());
                totalMins += mins;

                if (mins > 90 && mins <= 120)
                    gamesWithAddTime++;
                if (mins > 120)
                    gamesWithPenalties++;
            }

            double averageMins = (double) totalMins / gamesPlayed;

            Console.WriteLine($"{team} has played {totalMins} minutes. Average minutes per game: {averageMins:F2}");
            Console.WriteLine($"Games with penalties: {gamesWithPenalties}");
            Console.WriteLine($"Games with additional time: {gamesWithAddTime}");
        }
    }
}
