using System;

namespace _06_BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = "";
            int openingBracket = 0;
            int closingBracket = 0;
            bool isBalanced = false;

            for (int i = 1; i <= n; i++)
            {
                input = Console.ReadLine();

                if (input == "(")
                {
                    openingBracket++;
                }

                else if (input == ")")
                {
                    closingBracket++;

                    if (openingBracket == closingBracket)
                    {
                        isBalanced = true;
                        openingBracket = 0;
                        closingBracket = 0;
                    }

                    else
                    {
                        isBalanced = false;
                    }
                }
            }

            if (openingBracket != closingBracket)
            {
                isBalanced = false;
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }

            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
