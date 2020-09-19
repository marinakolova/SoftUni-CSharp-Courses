using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            this.DefaultFuelConsumption = 1.25;
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= DefaultFuelConsumption * kilometers;
        }
    }
}
