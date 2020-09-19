using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int combinations = 0;
            int sum = 0;

            for (int x5 = 0; x5 <= num; x5++)
            {
                for (int x4 = 0; x4 <= num; x4++)
                {
                    for (int x3 = 0; x3 <= num; x3++)
                    {
                        for (int x2 = 0; x2 <= num; x2++)
                        {
                            for (int x1 = 0; x1 <= num; x1++)
                            {
                                sum = x1 + x2 + x3 + x4 + x5;
                                if (sum == num)
                                {
                                    combinations++;
                                }                                
                            }
                        }
                    }
                }
            }

            Console.WriteLine(combinations);
        }
    }
}
