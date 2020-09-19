using System;
using System.Linq;

namespace _04_Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stoneValues = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var stones = new Lake<int>(stoneValues);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
