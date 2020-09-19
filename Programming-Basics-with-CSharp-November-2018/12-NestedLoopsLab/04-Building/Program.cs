using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfFloors = int.Parse(Console.ReadLine());
            int roomsPerFloor = int.Parse(Console.ReadLine());

            for (int floor = numOfFloors; floor >= 1; floor--)
            {
                for (int room = 0; room < roomsPerFloor; room++)
                {
                    if (floor == numOfFloors)
                    {
                        Console.Write($"L{floor}{room} ");
                    }

                    else if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }

                    else if (floor % 2 != 0)
                    {                        
                        Console.Write($"A{floor}{room} ");
                    }                    
                }

                Console.WriteLine();
            }
        }
    }
}
