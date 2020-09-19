using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get => this.name;

            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("People can't have a negative age.");
                }

                this.age = value;
            }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
