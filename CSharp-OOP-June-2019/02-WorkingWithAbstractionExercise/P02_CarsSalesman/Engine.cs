using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\t{this.Model}:");
            sb.AppendLine($"\t\tPower: {this.Power}");
            sb.AppendLine($"\t\tDisplacement: {this.Displacement}");
            sb.Append($"\t\tEfficiency: {this.Efficiency}");

            return sb.ToString();
        }
    }
}
