using System;
using System.Linq;

namespace _04_Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
