using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);

                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);

                double tire3Pressure = double.Parse(parameters[9]);
                int tire3Age = int.Parse(parameters[10]);

                double tire4Pressure = double.Parse(parameters[11]);
                int tire4Age = int.Parse(parameters[12]);

                cars.Add(new Car(model, 
                    engineSpeed, enginePower, 
                    cargoWeight, cargoType, 
                    tire1Pressure, tire1age, 
                    tire2Pressure, tire2age, 
                    tire3Pressure, tire3Age, 
                    tire4Pressure, tire4Age));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(y => y.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }

            else if (command == "flamable")
            {
                foreach (var car in cars
                    .Where(x => x.Cargo.Type == "flamable")
                    .Where(y => y.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
