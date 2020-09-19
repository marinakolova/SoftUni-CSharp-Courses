using System;

namespace _4_SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = symbols[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;
            bool isPrinted = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        if (!isPrinted)
                        {
                            Console.WriteLine($"({row}, {col})");
                            isFound = true;
                            isPrinted = true;
                            break;
                        }
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
