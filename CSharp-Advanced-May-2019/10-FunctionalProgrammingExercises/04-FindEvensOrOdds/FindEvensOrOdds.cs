using System;

namespace _04_FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var lowerRange = int.Parse(range[0]);
            var upperRange = int.Parse(range[1]);

            var condition = Console.ReadLine();

            Predicate<int> isEven = x => x % 2 == 0;

            for (int i = lowerRange; i <= upperRange; i++)
            {
                if (condition == "even" && isEven(i))
                {
                    Console.Write(i + " ");
                }
                else if (condition == "odd" && !isEven(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
