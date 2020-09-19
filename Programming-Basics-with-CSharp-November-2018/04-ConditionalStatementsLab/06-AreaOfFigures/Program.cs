using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFigure = Console.ReadLine();

            if (typeOfFigure == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                double squareArea = squareSide * squareSide;
                Console.WriteLine(Math.Round(squareArea, 3));
            }

            else if (typeOfFigure == "rectangle")
            {
                double rectangleSideA = double.Parse(Console.ReadLine());
                double rectangleSideB = double.Parse(Console.ReadLine());
                double rectangleArea = rectangleSideA * rectangleSideB;
                Console.WriteLine(Math.Round(rectangleArea, 3));
            }

            else if (typeOfFigure == "circle")
            {
                double circleRadius = double.Parse(Console.ReadLine());
                double circleArea = Math.PI * circleRadius * circleRadius;
                Console.WriteLine(Math.Round(circleArea, 3));
            }

            else if (typeOfFigure == "triangle")
            {
                double triangleSide = double.Parse(Console.ReadLine());
                double triangleHeigth = double.Parse(Console.ReadLine());
                double triangleArea = (triangleSide * triangleHeigth) / 2;
                Console.WriteLine(Math.Round(triangleArea, 3));
            }
        }
    }
}
