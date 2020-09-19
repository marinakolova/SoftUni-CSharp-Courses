using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_NumberTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int current = 1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    current = row + col + 1;

                    if (current > n)
                    {
                        current = 2 * n - current;
                    }

                    Console.Write(current + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
