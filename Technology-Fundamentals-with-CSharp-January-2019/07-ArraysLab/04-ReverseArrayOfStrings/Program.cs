using System;
using System.Linq;

namespace _04_ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            // string[] output = input.Reverse().ToArray();
            
            Console.Write(input[input.Length - 1]);
            
            for (int i = input.Length - 2; i >= 0; i--)
            {
                Console.Write(" " + input[i]);
            }
            
            Console.WriteLine();
        }
    }
}
