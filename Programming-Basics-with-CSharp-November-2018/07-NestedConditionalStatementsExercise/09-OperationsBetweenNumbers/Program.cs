using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            double result = 0;
            string evenOrOdd = "";
            
            if (operation == "+")
            {
                result = num1 + num2;

                if (result % 2 == 0)
                    evenOrOdd = "even";
                else
                    evenOrOdd = "odd";

                Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
            }

            else if (operation == "-")
            {
                result = num1 - num2;

                if (result % 2 == 0)
                    evenOrOdd = "even";
                else
                    evenOrOdd = "odd";

                Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
            }

            else if (operation == "*")
            {
                result = num1 * num2;

                if (result % 2 == 0)
                    evenOrOdd = "even";
                else
                    evenOrOdd = "odd";

                Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
            }

            else if (operation == "/" && num2 != 0)
            {
                result = (double)num1 / num2;
                Console.WriteLine($"{num1} {operation} {num2} = {result:F2}");
            }

            else if (operation == "/" && num2 == 0)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }

            else if (operation == "%" && num2 != 0)
            {
                result = num1 % num2;
                Console.WriteLine($"{num1} {operation} {num2} = {result}");
            }

            else if (operation == "%" && num2 == 0)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
        }
    }
}
