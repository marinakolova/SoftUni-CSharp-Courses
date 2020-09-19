using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine(this.Start());
            sb.Append(this.Stop());

            return sb.ToString();
        }
    }
}
