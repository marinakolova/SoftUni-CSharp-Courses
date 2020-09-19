using System;

namespace _01_DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "int":
                    int intNum = int.Parse(Console.ReadLine());
                    PrintResult(intNum);                    
                    break;

                case "real":
                    double doubleNum = double.Parse(Console.ReadLine());
                    PrintResult(doubleNum);
                    break;

                case "string":
                    string strInput = Console.ReadLine();
                    PrintResult(strInput);
                    break;
            }
        }

        private static void PrintResult(int intNum)
        {
            int result = intNum * 2;
            Console.WriteLine(result);
        }

        private static void PrintResult(double doubleNum)
        {
            double result = doubleNum * 1.5;
            Console.WriteLine($"{result:F2}");
        }

        private static void PrintResult(string strInput)
        {
            Console.WriteLine("$" + strInput + "$");
        }
    }
}
