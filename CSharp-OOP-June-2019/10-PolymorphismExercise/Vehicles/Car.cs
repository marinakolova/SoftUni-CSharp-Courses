using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double AirConditionerCoeff { get; set; }

        public double TankCapacity { get; set; }

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
            this.AirConditionerCoeff = 0.9;
            this.TankCapacity = tankCapacity;
        }

        public void Drive(double distance)
        {
            var neededFuel = (this.FuelConsumption + this.AirConditionerCoeff) * distance;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
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
            return $"Car: {this.FuelQuantity:F2}";
        }
    }
}
