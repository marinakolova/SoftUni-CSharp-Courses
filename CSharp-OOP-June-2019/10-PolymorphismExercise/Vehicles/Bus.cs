using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double AirConditionerCoeff { get; set; }

        public double TankCapacity { get; set; }

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumption;
            this.AirConditionerCoeff = 1.4;
            this.TankCapacity = tankCapacity;
        }

        public void Drive(double distance)
        {
            var neededFuel = (this.FuelConsumption + this.AirConditionerCoeff) * distance;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            var neededFuel = this.FuelConsumption * distance;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:F2}";
        }
    }
}
