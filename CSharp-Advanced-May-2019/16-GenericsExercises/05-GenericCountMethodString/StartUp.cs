using System;

namespace _05_GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }

            var elementToCompare = Console.ReadLine();

            Console.WriteLine(box.Compare(elementToCompare));
        }
    }
}
