using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = carInfo[4];
                var tire1Pressure = double.Parse(carInfo[5]);
                var tire1Age = int.Parse(carInfo[6]);
                var tire2Pressure = double.Parse(carInfo[7]);
                var tire2Age = int.Parse(carInfo[8]);
                var tire3Pressure = double.Parse(carInfo[9]);
                var tire3Age = int.Parse(carInfo[10]);
                var tire4Pressure = double.Parse(carInfo[11]);
                var tire4Age = int.Parse(carInfo[12]);

                var engine = new Engine(engineSpeed, enginePower);

                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new Tire[4] 
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                };

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Tires[0].Pressure < 1
                        || x.Tires[1].Pressure < 1
                        || x.Tires[2].Pressure < 1
                        || x.Tires[3].Pressure < 1))
                {
                    Console.WriteLine(car.Model);
                }
            }

            else if (command == "flamable")
            {
                foreach (var car in cars
                    .Where(x => x.Cargo.Type == "flamable")
                    .Where(x => x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
