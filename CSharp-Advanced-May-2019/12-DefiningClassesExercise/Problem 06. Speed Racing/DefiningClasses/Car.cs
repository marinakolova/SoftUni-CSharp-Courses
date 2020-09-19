using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionFor1km;
            this.TravelledDistance = 0;
        }

        public void Drive(double amountOfKm)
        {
            var usedFuel = this.FuelConsumptionPerKilometer * amountOfKm;

            if (this.FuelAmount >= usedFuel)
            {
                this.FuelAmount -= usedFuel;
                this.TravelledDistance += amountOfKm;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
