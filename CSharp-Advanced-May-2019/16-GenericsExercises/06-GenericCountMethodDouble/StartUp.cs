using System;

namespace _06_GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            var elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Compare(elementToCompare));
        }
    }
}
