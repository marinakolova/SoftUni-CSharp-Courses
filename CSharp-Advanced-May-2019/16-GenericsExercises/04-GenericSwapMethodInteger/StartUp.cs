using System;
using System.Linq;

namespace _04_GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(indexes[0], indexes[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
