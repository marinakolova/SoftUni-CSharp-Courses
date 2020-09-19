using System;

namespace _06_CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double area = GetRectangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double GetRectangleArea(int width, int height)
        {
            return width * height;
        }
    }
}
