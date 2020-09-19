using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cells = Console.ReadLine().Split("#").ToList();
            int water = int.Parse(Console.ReadLine());

            double totalEffort = 0;
            List<int> putOutCells = new List<int>();
            double totalFire = 0;

            for (int i = 0; i < cells.Count; i++)
            {
                string[] currCell = cells[i].Split(" = ");
                int valueOfCell = int.Parse(currCell[1]);
                string typeOfFire = currCell[0];

                if ((typeOfFire == "High" && valueOfCell >= 81 && valueOfCell <= 125)
                    || (typeOfFire == "Medium" && valueOfCell >= 51 && valueOfCell <= 80)
                    || (typeOfFire == "Low" && valueOfCell >= 1 && valueOfCell <=50))
                {
                    if (water >= valueOfCell)
                    {
                        water -= valueOfCell;
                        double effort = 0.25 * valueOfCell;
                        totalEffort += effort;
                        putOutCells.Add(valueOfCell);
                        totalFire += valueOfCell;
                    }                                  
                }
            }

            Console.WriteLine("Cells:");

            foreach (var cell in putOutCells)
            {
                Console.WriteLine($"- {cell}");
            }

            Console.WriteLine($"Effort: {totalEffort:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
