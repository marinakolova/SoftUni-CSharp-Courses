using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallest = int.MaxValue;
            int biggest = int.MinValue;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                int num = int.Parse(command);
                if (num < smallest)
                {
                    smallest = num;
                }
                if (num > biggest)
                {
                    biggest = num;
                }
            }
            Console.WriteLine($"Max number: {biggest}");
            Console.WriteLine($"Min number: {smallest}");
        }
    }
}
