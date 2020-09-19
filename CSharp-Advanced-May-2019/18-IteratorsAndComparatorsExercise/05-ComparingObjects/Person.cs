using System;
using System.Collections.Generic;
using System.Text;

namespace _05_ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(params string[] data)
        {
            this.name = data[0];
            this.age = int.Parse(data[1]);
            this.town = data[2];
        }

        public int CompareTo(Person other)
        {
            if (this.name.CompareTo(other.name) != 0)
            {
                return this.name.CompareTo(other.name);
            }

            if (this.age.CompareTo(other.age) != 0)
            {
                return this.age.CompareTo(other.age);
            }

            if (this.town.CompareTo(other.town) != 0)
            {
                return this.town.CompareTo(other.town);
            }

            return 0;
        }
    }
}
