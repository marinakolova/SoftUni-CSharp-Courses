using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ChallengeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            int dates = 0;

            
            for (int m = 1; m <= men; m++)
            {
                for (int f = 1; f <= women; f++)
                {
                    Console.Write($"({m} <-> {f}) ");
                    dates++;

                    if (dates >= tables)
                    {
                        return;
                    }
                }
            }   

        }
    }
}
