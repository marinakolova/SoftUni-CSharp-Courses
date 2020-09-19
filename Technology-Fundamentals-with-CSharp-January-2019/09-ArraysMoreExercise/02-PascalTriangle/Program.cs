using System;

namespace _02_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] lines = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                lines[i] = new int[i + 1];
            }

            for (int j = 0; j < rows; j++)
            {
                lines[j][0] = 1;
                lines[j][lines[j].Length - 1] = 1;
            }

            for (int k = 1; k < rows; k++)
            {
                if (k == 1)
                {
                    lines[k][k] = 1;
                }
                else
                {
                    for (int m = 1; m < lines[k].Length - 1; m++)
                    {
                        lines[k][m] = lines[k - 1][m - 1]
                                    + lines[k - 1][m];
                    }                    
                }
            }

            for (int l = 0; l < rows; l++)
            {
                Console.WriteLine(String.Join(" ", lines[l]));
            }
        }
    }
}
