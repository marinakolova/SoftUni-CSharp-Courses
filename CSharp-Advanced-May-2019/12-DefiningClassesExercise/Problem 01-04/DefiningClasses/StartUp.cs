using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personInfo[0], int.Parse(personInfo[1])));
            }

            foreach (var person in people
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
