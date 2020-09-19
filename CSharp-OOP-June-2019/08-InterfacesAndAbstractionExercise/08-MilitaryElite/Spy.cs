using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Spy : Soldier
    {
        public int CodeNumber { get; set; }

        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.Append($"Code Number: {this.CodeNumber}");

            return sb.ToString();
        }
    }
}
