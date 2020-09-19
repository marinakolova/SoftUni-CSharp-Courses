using System;
using System.Collections.Generic;

namespace _04_EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                var num = Console.ReadLine();

                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }
                dict[num]++;
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
