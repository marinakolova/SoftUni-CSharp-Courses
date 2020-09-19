using System;
using System.Numerics;

namespace _11_Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int snow = 0;
            int time = 0;
            int quality = 0;
            BigInteger value = 0;
            BigInteger highestValue = 0;

            int snowtp = 0;
            int timetp = 0;
            BigInteger valuetp = 0;
            int qualitytp = 0;

            for (int i = 1; i <= n; i++)
            {
                snow = int.Parse(Console.ReadLine());
                time = int.Parse(Console.ReadLine());
                quality = int.Parse(Console.ReadLine());

                int snowDevByTime = snow / time;

                value = BigInteger.Pow(snowDevByTime, quality);

                if (value >= highestValue)
                {
                    snowtp = snow;
                    timetp = time;
                    valuetp = value;
                    qualitytp = quality;

                    highestValue = value;
                }
            }

            Console.WriteLine($"{snowtp} : {timetp} = {valuetp} ({qualitytp})");
        }
    }
}
