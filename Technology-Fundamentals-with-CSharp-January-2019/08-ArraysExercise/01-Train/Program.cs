using System;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagons = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
            }

            foreach (var people in wagons)
            {
                Console.Write(people + " ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
