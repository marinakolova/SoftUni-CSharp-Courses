using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        private const int MIN_AGE = 12;
        private const int MAX_AGE = 90;

        public Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; private set; }

        [MyRangeAttribute(MIN_AGE, MAX_AGE)]
        public int Age { get; private set; }
    }
}
