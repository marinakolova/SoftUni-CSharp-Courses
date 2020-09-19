using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialCars
{
    class Program
    {
        static void Main(string[] args)
        {
            var tires = new List<Tire[]>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }

                var tireInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var year = int.Parse(tireInfo[0]);
                var pressure = double.Parse(tireInfo[1]);
                var tire1 = new Tire(year, pressure);

                year = int.Parse(tireInfo[2]);
                pressure = double.Parse(tireInfo[3]);
                var tire2 = new Tire(year, pressure);

                year = int.Parse(tireInfo[4]);
                pressure = double.Parse(tireInfo[5]);
                var tire3 = new Tire(year, pressure);

                year = int.Parse(tireInfo[6]);
                pressure = double.Parse(tireInfo[7]);
                var tire4 = new Tire(year, pressure);

                tires.Add(new Tire[4] { tire1, tire2, tire3, tire4, });
            }

            var engines = new List<Engine>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                var engineInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var horsePower = int.Parse(engineInfo[0]);
                var cubicCapacity = double.Parse(engineInfo[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            var cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }

                var carInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var make = carInfo[0];
                var model = carInfo[1];
                var year = int.Parse(carInfo[2]);
                var fuelQuantity = double.Parse(carInfo[3]);
                var fuelConsumption = double.Parse(carInfo[4]);
                var engineIndex = int.Parse(carInfo[5]);
                var tiresIndex = int.Parse(carInfo[6]);

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }

            foreach (var car in cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10))
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(
            string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(
            string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            double consumed = distance * (FuelConsumption / 100);

            if (FuelQuantity - consumed >= 0)
            {
                FuelQuantity -= consumed;
            }

            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");

            return sb.ToString();
        }
    }

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public int Year { get; set; }
        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
