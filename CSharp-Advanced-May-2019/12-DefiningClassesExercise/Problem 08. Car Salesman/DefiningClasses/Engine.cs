using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine()
        {
            this.Model = "n/a";
            this.Power = "n/a";
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public Engine(string model, string power)
            : this()
        {
            this.Model = model;
            this.Power = power;
        }
    }
}
