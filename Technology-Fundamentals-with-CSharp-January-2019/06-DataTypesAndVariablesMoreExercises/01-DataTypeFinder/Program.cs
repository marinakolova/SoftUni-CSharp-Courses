using System;

namespace _01_DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool tryBoolean;
            char tryChar;
            double tryDouble;
            int tryInt;


            while (input != "END")
            {
                if (int.TryParse(input, out tryInt))
                {
                    Console.WriteLine($"{input} is integer type");
                }

                else if (double.TryParse(input, out tryDouble))
                {
                    Console.WriteLine($"{input} is floating point type");
                }

                else if (char.TryParse(input, out tryChar))
                {
                    Console.WriteLine($"{input} is character type");
                }

                else if (bool.TryParse(input, out tryBoolean))
                {
                    Console.WriteLine($"{input} is boolean type");
                }

                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
