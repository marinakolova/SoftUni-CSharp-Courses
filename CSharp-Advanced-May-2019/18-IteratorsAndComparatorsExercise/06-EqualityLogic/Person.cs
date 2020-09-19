using System;
using System.Collections.Generic;
using System.Text;

namespace _06_EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public string Name => this.name;
        public int Age => this.age;

        public Person(params string[] data)
        {
            this.name = data[0];
            this.age = int.Parse(data[1]);
        }

        public int CompareTo(Person other)
        {
            var comparison = this.Name.CompareTo(other.Name);

            return comparison == 0
                ? this.Age.CompareTo(other.Age)
                : comparison;
        }
    }
}
