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
                var fuelAmount = double.Parse(carInfo[1]);
                var fuelConsumptionFor1km = double.Parse(carInfo[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1km));
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = partsOfCommand[1];
                var amountOfKm = double.Parse(partsOfCommand[2]);

                cars.Where(x => x.Model == carModel).FirstOrDefault().Drive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
