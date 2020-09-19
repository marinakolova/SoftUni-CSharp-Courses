using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ChristmasDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            string item = "";

            while (command != "Stop")
            {
                item = command;

                byte[] asciiBytes = Encoding.ASCII.GetBytes(item);

                int total = 0;

                foreach (var i in asciiBytes)
                {
                    total += i;
                }

                if (total <= budget)
                {
                    Console.WriteLine("Item successfully purchased!");
                    budget -= total;
                    command = Console.ReadLine();
                }

                else if (total > budget)
                {
                    Console.WriteLine("Not enough money!");
                    break;
                }
            }

            if (command == "Stop")
            {
                Console.WriteLine($"Money left: {budget}");
            }
        }
    }
}
