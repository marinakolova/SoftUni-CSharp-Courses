using System;

namespace _02_CenterPodouble
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintTheClosestPoint(x1, y1, x2, y2);
        }

        private static void PrintTheClosestPoint(double x1, double y1, double x2, double y2)
        {
            double distance1 = Math.Sqrt(Math.Abs(x1) * Math.Abs(x1) + Math.Abs(y1) * Math.Abs(y1));
            double distance2 = Math.Sqrt(Math.Abs(x2) * Math.Abs(x2) + Math.Abs(y2) * Math.Abs(y2));

            if (distance1 <= distance2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
