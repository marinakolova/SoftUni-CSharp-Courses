using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Commando : SpecialisedSoldier
    {
        public List<Mission> Missions { get; set; }

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            if (this.Missions.Count > 0)
            {
                foreach (var mission in this.Missions)
                {
                    sb.AppendLine($"  {mission.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
