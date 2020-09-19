using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int prevSum = 0;
            int diff = 0;
            int maxDiff = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                sum = num1 + num2;

                if (i > 1)
                {
                    diff = Math.Abs(sum - prevSum);
                }

                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }

                prevSum = sum;
                sum = 0;
            }

            if (maxDiff == 0)
                Console.WriteLine($"Yes, value={prevSum}");
            else
                Console.WriteLine($"No, maxdiff={maxDiff}");
        }
    }
}
