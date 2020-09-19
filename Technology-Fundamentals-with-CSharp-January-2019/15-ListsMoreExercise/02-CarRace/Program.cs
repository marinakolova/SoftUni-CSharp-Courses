using System;
using System.Linq;

namespace _02_CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] times = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double leftRacer = 0;
            double rightRacer = 0;

            for (int i = 0; i < (times.Length - 1) / 2; i++)
            {
                if (times[i] != 0)
                {
                    leftRacer += times[i];
                }

                else
                {
                    leftRacer = leftRacer * 0.8;
                }
            }

            for (int i = times.Length - 1; i > (times.Length - 1) / 2; i--)
            {
                if (times[i] != 0)
                {
                    rightRacer += times[i];
                }

                else
                {
                    rightRacer = rightRacer * 0.8;
                }
            }

            if (leftRacer < rightRacer)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacer}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightRacer}");
            }
        }
    }
}
