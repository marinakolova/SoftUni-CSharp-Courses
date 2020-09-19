using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double AirConditionerCoeff { get; set; }

        public double TankCapacity { get; set; }

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
            this.AirConditionerCoeff = 1.6;
            this.TankCapacity = tankCapacity;
        }

        public void Drive(double distance)
        {
            var neededFuel = (this.FuelConsumption + this.AirConditionerCoeff) * distance;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
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
                this.FuelQuantity += 0.95 * liters;
            }
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:F2}";
        }
    }
}
