using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int SpeedMotorcycleCubicCentimeters = 125;
        private const int SpeedMotorcycleMinHorsePower = 50;
        private const int SpeedMotorcycleMaxHorsePower = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, SpeedMotorcycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < SpeedMotorcycleMinHorsePower || value > SpeedMotorcycleMaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
    }
}
