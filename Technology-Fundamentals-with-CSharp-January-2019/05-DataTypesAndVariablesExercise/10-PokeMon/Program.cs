using System;

namespace _10_PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int targets = 0;
            int originN = N;

            while (N >= M)
            {
                N -= M;
                targets++;

                if (N == originN * 0.5)
                {
                    if (N >= Y && Y != 0)
                    {
                        N = N / Y;
                    }
                }
            }

            Console.WriteLine(N);
            Console.WriteLine(targets);
        }
    }
}
