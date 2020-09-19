using System;
using System.Linq;

namespace _2_PointInRectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] coordinates = ReadInput();

            Point topLeft = new Point(coordinates[0], coordinates[1]);
            Point bottomRight = new Point(coordinates[2], coordinates[3]);

            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pointCoordinates = ReadInput();

                Point pointToCheck = new Point(pointCoordinates[0], pointCoordinates[1]);

                Console.WriteLine(rectangle.Contains(pointToCheck));
            }
        }

        private static int[] ReadInput()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
