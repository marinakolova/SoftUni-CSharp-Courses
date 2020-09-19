using System;
using System.Collections.Generic;

namespace _06_VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();
            List<double> carsHorsePowers = new List<double>();
            List<double> trucksHorsePowers = new List<double>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] line = input.Split();

                Vehicle newVehicle = new Vehicle();

                newVehicle.Type = line[0];
                newVehicle.Model = line[1];
                newVehicle.Color = line[2];
                newVehicle.HorsePower = double.Parse(line[3]);

                catalogue.Add(newVehicle);

                if (newVehicle.Type == "car")
                {
                    carsHorsePowers.Add(newVehicle.HorsePower);
                }
                else if (newVehicle.Type == "truck")
                {
                    trucksHorsePowers.Add(newVehicle.HorsePower);
                }
            }

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    break;
                }

                int indexOfVehicle = catalogue.FindIndex(x => x.Model == model);

                if (catalogue[indexOfVehicle].Type == "car")
                {
                    Console.WriteLine("Type: Car");
                }
                else if (catalogue[indexOfVehicle].Type == "truck")
                {
                    Console.WriteLine("Type: Truck");
                }

                Console.WriteLine($"Model: {catalogue[indexOfVehicle].Model}");
                Console.WriteLine($"Color: {catalogue[indexOfVehicle].Color}");
                Console.WriteLine($"Horsepower: {catalogue[indexOfVehicle].HorsePower}");
            }

            double avgCarsHorsePower = GetAverageHorsePower(carsHorsePowers);
            double avgTrucksHorsePower = GetAverageHorsePower(trucksHorsePowers);

            Console.WriteLine($"Cars have average horsepower of: {avgCarsHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTrucksHorsePower:F2}.");
        }

        private static double GetAverageHorsePower(List<double> horsePowers)
        {
            double sum = 0;
            foreach (var vehicle in horsePowers)
            {
                sum += vehicle;
            }

            if (sum == 0)
            {
                return 0;
            }
            else
            {
                double average = sum / horsePowers.Count;

                return average;
            }            
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }
}
