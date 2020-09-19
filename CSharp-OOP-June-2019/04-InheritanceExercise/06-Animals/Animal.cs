using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        private int Age
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        private string Gender
        {
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || !Enum.TryParse<Gender>(value, out Gender gender))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = gender;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.name} {this.age} {this.gender.ToString()}");
            sb.Append($"{this.ProduceSound()}");

            return sb.ToString();
        }
    }
}
