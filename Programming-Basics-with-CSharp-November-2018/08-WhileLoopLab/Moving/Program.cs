using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving
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
            int totalBoxes = 0;

            while (command != "Done")
            {
                boxesCount = int.Parse(command);
                totalBoxes += boxesCount;
                currentCapacity -= boxesCount;
                
                if (currentCapacity < 0)
                {
                    int metersNeeded = totalBoxes - roomArea;
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
