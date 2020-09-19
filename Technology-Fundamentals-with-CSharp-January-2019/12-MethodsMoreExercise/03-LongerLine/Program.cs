using System;

namespace _03_LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintTheLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        private static void PrintTheLongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double distance1 = Math.Sqrt(Math.Abs(x1) * Math.Abs(x1) + Math.Abs(y1) * Math.Abs(y1));
            double distance2 = Math.Sqrt(Math.Abs(x2) * Math.Abs(x2) + Math.Abs(y2) * Math.Abs(y2));
            double distance3 = Math.Sqrt(Math.Abs(x3) * Math.Abs(x3) + Math.Abs(y3) * Math.Abs(y3));
            double distance4 = Math.Sqrt(Math.Abs(x4) * Math.Abs(x4) + Math.Abs(y4) * Math.Abs(y4));

            if (distance1 + distance2 >= distance3 + distance4)
            {
                if (distance1 <= distance2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y2})");
                }
            }
            else
            {
                if (distance3 <= distance4)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
    }
}
