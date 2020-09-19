using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int roomWidth = int.Parse(Console.ReadLine());
            int roomLength = int.Parse(Console.ReadLine());
            int roomHeigth = int.Parse(Console.ReadLine());

            int roomArea = roomWidth * roomLength * roomHeigth;

            string command = Console.ReadLine();
            int currentCapacity = roomArea;
            int boxesCount = 0;

            while (command != "Done")
            {
                boxesCount = int.Parse(command);
                currentCapacity -= boxesCount;
                boxesCount += boxesCount;

                if (currentCapacity < 0)
                {
                    int metersNeeded = roomArea - boxesCount;
                    Console.WriteLine($"No more free space! You need {metersNeeded} Cubic meters more.");
                    break;
                }

                command = Console.ReadLine();
            }

            if (currentCapacity >= 0)
            {
                Console.WriteLine($"{currentCapacity} Cubic meters left.");
            }
        }
    }
}
