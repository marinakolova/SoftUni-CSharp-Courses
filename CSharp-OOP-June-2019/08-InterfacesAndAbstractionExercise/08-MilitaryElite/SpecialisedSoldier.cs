using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class SpecialisedSoldier : Private
    {
        public string Corps { get; set; }

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
    }
}
