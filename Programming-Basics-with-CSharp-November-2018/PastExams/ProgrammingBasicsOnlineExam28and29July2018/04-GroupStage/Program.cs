using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());

            int score = 0;
            int totalGoalsScored = 0;
            int totalGoalsReceived = 0;
            int goalsScored = 0;
            int goalsReceived = 0;

            for (int i = 0; i < games; i++)
            {
                goalsScored = int.Parse(Console.ReadLine());
                goalsReceived = int.Parse(Console.ReadLine());

                totalGoalsReceived += goalsReceived;
                totalGoalsScored += goalsScored;

                if (goalsScored > goalsReceived)
                    score += 3;
                else if (goalsScored == goalsReceived)
                    score += 1;
            }

            int goalDiff = totalGoalsScored - totalGoalsReceived;

            if (totalGoalsScored >= totalGoalsReceived)
            {
                Console.WriteLine($"{team} has finished the group phase with {score} points.");
                Console.WriteLine($"Goal difference: {goalDiff}.");
            }

            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {goalDiff}.");
            }
        }
    }
}
