using System;
using System.Collections.Generic;

namespace _04_CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!dict.ContainsKey(continent))
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!dict[continent].ContainsKey(country))
                {
                    dict[continent].Add(country, new List<string>());
                }
                dict[continent][country].Add(city);
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var cntry in item.Value)
                {
                    Console.WriteLine($"{cntry.Key} -> {string.Join(", ", cntry.Value)}");
                }
            }
        }
    }
}
