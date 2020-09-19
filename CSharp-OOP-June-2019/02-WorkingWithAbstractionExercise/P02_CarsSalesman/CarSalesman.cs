using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class CarSalesman
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = engineInfo[0];
                var power = engineInfo[1];

                var engine = new Engine(model, power);

                if (engineInfo.Length == 3)
                {
                    if (char.IsDigit(engineInfo[2][0]))
                    {
                        engine.Displacement = engineInfo[2];
                    }
                    else
                    {
                        engine.Efficiency = engineInfo[2];
                    }
                }

                else if (engineInfo.Length == 4)
                {
                    engine.Displacement = engineInfo[2];
                    engine.Efficiency = engineInfo[3];
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var engineModel = carInfo[1];

                var currEngine = engines.Where(x => x.Model == engineModel).FirstOrDefault();

                var car = new Car(model, currEngine);

                if (carInfo.Length == 3)
                {
                    if (char.IsDigit(carInfo[2][0]))
                    {
                        car.Weight = carInfo[2];
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }
                }

                else if (carInfo.Length == 4)
                {
                    car.Weight = carInfo[2];
                    car.Color = carInfo[3];
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
