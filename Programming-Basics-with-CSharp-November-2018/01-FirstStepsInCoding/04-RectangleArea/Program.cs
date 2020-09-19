using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A:");
            var a = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter B:");
            var b = double.Parse(Console.ReadLine());

            Console.WriteLine("The Rectangle Area is:");
            Console.WriteLine(a * b);
        }
    }
}
