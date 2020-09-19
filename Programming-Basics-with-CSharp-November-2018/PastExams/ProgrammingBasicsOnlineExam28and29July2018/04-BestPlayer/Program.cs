using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = "";
            int goals = 0;
            int maxGoals = int.MinValue;
            string bestPlayer = "";

            while (goals < 10)
            {
                player = Console.ReadLine();

                if (player == "END")
                    break;

                goals = int.Parse(Console.ReadLine());

                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    bestPlayer = player;                    
                }
            }

            Console.WriteLine($"{bestPlayer} is the best player!");

            if (goals >= 3)
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            else
                Console.WriteLine($"He has scored {maxGoals} goals.");
        }
    }
}
