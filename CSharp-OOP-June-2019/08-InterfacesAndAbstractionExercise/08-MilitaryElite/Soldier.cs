using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Soldier
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
