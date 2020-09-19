using System;
using System.Collections.Generic;

namespace _07_FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    people.Add(input[0], "citizen");
                }
                else
                {
                    people.Add(input[0], "rebel");
                }
            }

            var food = 0;

            while (true)
            {
                var buyer = Console.ReadLine();

                if (buyer == "End")
                {
                    break;
                }

                if (people.ContainsKey(buyer))
                {
                    if (people[buyer] == "citizen")
                    {
                        food += 10;
                    }
                    else if (people[buyer] == "rebel")
                    {
                        food += 5;
                    }
                }
            }

            Console.WriteLine(food);
        }
    }
}
