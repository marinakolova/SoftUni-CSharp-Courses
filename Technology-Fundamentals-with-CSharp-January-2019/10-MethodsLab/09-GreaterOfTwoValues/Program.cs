using System;

namespace _09_GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":

                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    int greater = GetMax(a, b);
                    Console.WriteLine(greater);
                    break;

                case "char":

                    char one = char.Parse(Console.ReadLine());
                    char two = char.Parse(Console.ReadLine());
                    char greaterChar = GetMax(one, two);
                    Console.WriteLine(greaterChar);
                    break;

                case "string":

                    string first = Console.ReadLine();
                    string second = Console.ReadLine();
                    string greaterString = GetMax(first, second);
                    Console.WriteLine(greaterString);
                    break;
            }
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static string GetMax(string a, string b)
        {
            if (String.Compare(a, b) < 0)
            {
                return b;
            }
            
            else
            {
                return a;
            }
        }
    }
}
