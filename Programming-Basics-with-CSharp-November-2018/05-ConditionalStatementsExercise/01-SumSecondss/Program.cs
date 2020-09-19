using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SumSecondss
{
    class Program
    {
        static void Main(string[] args)
        {
            int secs1 = int.Parse(Console.ReadLine());
            int secs2 = int.Parse(Console.ReadLine());
            int secs3 = int.Parse(Console.ReadLine());

            int secsTotal = secs1 + secs2 + secs3;

            int seconds = secsTotal % 60;
            int minutes = secsTotal / 60;
            string time = minutes + ":" + seconds;

            Console.WriteLine(time);
        }
    }
}
