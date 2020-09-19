using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class LieutenantGeneral : Private
    {
        public List<Private> PrivatesUnderCommand { get; set; }

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.PrivatesUnderCommand = new List<Private>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine("Privates:");
            foreach (var priv in this.PrivatesUnderCommand)
            {
                sb.AppendLine($"  {priv.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
