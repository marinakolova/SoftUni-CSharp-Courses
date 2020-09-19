using System;

namespace _07_WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;
            int litersInTheTank = 0;

            for (int i = 1; i <= n; i++)
            {
                int litersToPour = int.Parse(Console.ReadLine());

                if (litersToPour <= capacity)
                {
                    capacity -= litersToPour;
                    litersInTheTank += litersToPour;
                }

                else if (litersToPour > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");                    
                }
            }

            Console.WriteLine(litersInTheTank);
        }
    }
}
