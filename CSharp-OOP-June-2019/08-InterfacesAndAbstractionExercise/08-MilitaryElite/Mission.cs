using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Mission
    {
        public string CodeName { get; set; }

        public string State { get; set; }

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
