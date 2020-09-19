using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int PowerMotorcycleCubicCentimeters = 450;
        private const int PowerMotorcycleMinHorsePower = 70;
        private const int PowerMotorcycleMaxHorsePower = 100;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, PowerMotorcycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < PowerMotorcycleMinHorsePower || value > PowerMotorcycleMaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
    }
}
