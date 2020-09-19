using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int cake = cakeLength * cakeWidth;
            
            int pieces = 0;

            string command = Console.ReadLine();

            while (command != "STOP" && cake >= 0)
            {
                pieces = int.Parse(command);
                cake = cake - pieces;
                command = Console.ReadLine();
            }
            
            if (cake >= 0)
                Console.WriteLine($"{cake} pieces are left.");
            else if (cake < 0)
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
        }
    }
}
