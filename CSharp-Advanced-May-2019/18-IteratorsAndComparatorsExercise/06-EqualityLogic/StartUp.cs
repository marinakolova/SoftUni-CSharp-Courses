using System;
using System.Collections.Generic;

namespace _06_EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sortedPeople = new SortedSet<Person>();
            var hashedPeople = new HashSet<Person>(new PersonEqualityComparer());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personToAdd = new Person(Console.ReadLine().Split());
                sortedPeople.Add(personToAdd);
                hashedPeople.Add(personToAdd);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashedPeople.Count);
        }
    }
}
