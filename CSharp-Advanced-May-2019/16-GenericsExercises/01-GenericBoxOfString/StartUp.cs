using System;

namespace _01_GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var box = new Box<string>(input);

                Console.WriteLine(box.ToString());
            }
        }
    }
}
