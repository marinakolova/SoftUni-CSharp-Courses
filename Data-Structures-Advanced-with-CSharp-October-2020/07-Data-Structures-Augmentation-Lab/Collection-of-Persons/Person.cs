using System;

namespace Collection_of_Persons
{
    public class Person : IComparable<Person>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person otherPerson)
        {
            return this.Email.CompareTo(otherPerson.Email);
        }
    }
}
