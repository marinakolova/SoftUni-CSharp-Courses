using System;
using System.Collections.Generic;

namespace _03_SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int amountOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfCars; i++)
            {
                cars.Add(new Car(Console.ReadLine().Split()));
            }

            string[] drive = Console.ReadLine().Split();

            while (drive[0] != "End")
            {
                cars.Find(c => c.Model == drive[1]).Drive(int.Parse(drive[2]));

                drive = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }

        }
    }

    class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumptionPerKm { get; set; }
        public int DistanceTraveled { get; set; }

        public Car(string[] carCharacteristics)
        {
            this.Model = carCharacteristics[0];
            this.FuelAmount = decimal.Parse(carCharacteristics[1]);
            this.FuelConsumptionPerKm = decimal.Parse(carCharacteristics[2]);

        }

        public void Drive(int distance)
        {
            decimal fuelNeeded = distance * this.FuelConsumptionPerKm;

            if (this.FuelAmount >= fuelNeeded)
            {
                this.DistanceTraveled += distance;
                this.FuelAmount -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}