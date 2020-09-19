using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomGender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, TomGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
