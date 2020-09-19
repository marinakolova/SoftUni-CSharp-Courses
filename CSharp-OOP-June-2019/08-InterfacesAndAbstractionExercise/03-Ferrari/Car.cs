using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Ferrari
{
    public abstract class Car : ICar
    {
        public string Model { get; set; }
        public string Driver { get; set; }

        public string PushTheGasPedal()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGasPedal()}/{this.Driver}";
        }
    }
}
