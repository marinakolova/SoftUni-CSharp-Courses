using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split();

                Person newPerson = new Person();

                newPerson.Name = data[0];
                newPerson.ID = data[1];
                newPerson.Age = int.Parse(data[2]);

                people.Add(newPerson);
            }

            people = people.OrderBy(x => x.Age).ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
