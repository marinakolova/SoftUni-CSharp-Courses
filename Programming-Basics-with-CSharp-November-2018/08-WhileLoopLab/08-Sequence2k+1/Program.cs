using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalNumber = int.Parse(Console.ReadLine());
            int k = 1;

            while (k <= finalNumber)
            {
                Console.WriteLine(k);
                k = (k * 2) + 1;
            }
        }
    }
}
