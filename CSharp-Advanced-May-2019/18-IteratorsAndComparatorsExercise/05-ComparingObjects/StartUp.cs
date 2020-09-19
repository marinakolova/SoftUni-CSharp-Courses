using System;
using System.Collections.Generic;

namespace _05_ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            var input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                people.Add(new Person(input));

                input = Console.ReadLine().Split();
            }

            int n = int.Parse(Console.ReadLine());

            int countOfMatches = 0;
            int numOfNotEqualPeople = 0;
            int totalNumOfPeople = 0;

            foreach (var person in people)
            {
                var comparrison = person.CompareTo(people[n - 1]);

                if (comparrison == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    numOfNotEqualPeople++;
                }

                totalNumOfPeople++;
            }

            if (countOfMatches > 1)
            {
                Console.WriteLine($"{countOfMatches} {numOfNotEqualPeople} {totalNumOfPeople}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
