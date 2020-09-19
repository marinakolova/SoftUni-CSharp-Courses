using System;

namespace _11_RefactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Console.WriteLine("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.WriteLine("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            double height = double.Parse(Console.ReadLine());
            double volume = (length * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");
            */

            double length = double.Parse(Console.ReadLine());            
            double width = double.Parse(Console.ReadLine());            
            double height = double.Parse(Console.ReadLine());
            double volume = (length * width * height) / 3;
            Console.Write("Length: ");
            Console.Write("Width: ");
            Console.Write("Height: ");
            Console.WriteLine($"Pyramid Volume: {volume:f2}");
        }
    }
}
