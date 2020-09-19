using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_WaterDispenser
{
    class Program
    {
        static void Main(string[] args)
        {
            int glass = int.Parse(Console.ReadLine());
            string button = "";
            int water = 0;
            int tapes = 0;

            while (water < glass)
            {
                button = Console.ReadLine();
                tapes++;

                if (button == "Easy")
                    water += 50;
                if (button == "Medium")
                    water += 100;
                if (button == "Hard")
                    water += 200;
            }

            int spilled = water - glass;

            if (water == glass)
                Console.WriteLine($"The dispenser has been tapped {tapes} times.");
            else if (water > glass)
                Console.WriteLine($"{spilled}ml has been spilled.");
        }
    }
}
