using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());
            int total = 0;
            
            for (char i = 'A'; i <= sector; i++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    if (j % 2 == 1)
                    {
                        for (int k = 1; k <= seats; k++)
                        {
                            Console.WriteLine($"{i}{j}{(char)(k + 96)}");
                            total++;
                        }
                    }

                    else if (j % 2 == 0)
                    {
                        for (int k = 1; k <= seats + 2; k++)
                        {
                            Console.WriteLine($"{i}{j}{(char)(k + 96)}");
                            total++;
                        }
                    }
                }

                rows++;
            }

            Console.WriteLine(total);
        }
    }
}
