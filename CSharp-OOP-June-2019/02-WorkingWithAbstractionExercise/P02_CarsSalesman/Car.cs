using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car()
        {
            this.Model = "n/a";
            this.Engine = new Engine();
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public Car(string model, Engine engine)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{this.Engine}");
            sb.AppendLine($"\tWeight: {this.Weight}");
            sb.Append($"\tColor: {this.Color}");

            return sb.ToString();
        }
    }
}
