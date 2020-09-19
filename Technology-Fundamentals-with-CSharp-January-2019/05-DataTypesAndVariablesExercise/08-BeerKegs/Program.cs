using System;

namespace _08_BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestVolume = double.MinValue;
            string biggestKeg = "";

            for (int i = 1; i <= n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;

                if (volume > biggestVolume)
                {
                    biggestKeg = model;
                    biggestVolume = volume;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
