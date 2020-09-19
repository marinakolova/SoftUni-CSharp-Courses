using System;

namespace _04_PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = firstNum; i <= lastNum; i++)
            {
                Console.Write(i + " ");
                sum += i;                
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
