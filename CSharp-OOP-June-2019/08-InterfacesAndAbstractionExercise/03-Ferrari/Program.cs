using System;

namespace _03_Ferrari
{
    public class Program
    {
        static void Main(string[] args)
        {
            var driver = Console.ReadLine();
            var ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
