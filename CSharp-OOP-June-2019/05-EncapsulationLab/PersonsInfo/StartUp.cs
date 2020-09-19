using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var firstName = data[0];
                var lastName = data[1];
                var age = int.Parse(data[2]);
                var salary = decimal.Parse(data[3]);

                try
                {
                    var person = new Person(firstName, lastName, age, salary);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var team = new Team("SoftUni");

            foreach (var person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
