using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] data = input.Split('/');

                if (data[0] == "Car")
                {
                    Car newCar = new Car();

                    newCar.Brand = data[1];
                    newCar.Model = data[2];
                    newCar.HorsePower = data[3];

                    cars.Add(newCar);
                }

                else if (data[0] == "Truck")
                {
                    Truck newTruck = new Truck();

                    newTruck.Brand = data[1];
                    newTruck.Model = data[2];
                    newTruck.Weight = data[3];

                    trucks.Add(newTruck);
                }
            }

            Console.WriteLine("Cars:");
            cars = cars.OrderBy(x => x.Brand).ToList();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            trucks = trucks.OrderBy(x => x.Brand).ToList();
            foreach (var truck in trucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
}
