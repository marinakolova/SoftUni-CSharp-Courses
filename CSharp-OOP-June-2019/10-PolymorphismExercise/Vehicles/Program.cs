using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            var truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Drive")
                {
                    switch (command[1])
                    {
                        case "Car":
                            car.Drive(double.Parse(command[2]));
                            break;

                        case "Truck":
                            truck.Drive(double.Parse(command[2]));
                            break;

                        case "Bus":
                            bus.Drive(double.Parse(command[2]));
                            break;
                    }
                }
                else if (command[0] == "Refuel")
                {
                    if (double.Parse(command[2]) <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                    }
                    else
                    {
                        switch (command[1])
                        {
                            case "Car":
                                car.Refuel(double.Parse(command[2]));
                                break;

                            case "Truck":
                                truck.Refuel(double.Parse(command[2]));
                                break;

                            case "Bus":
                                bus.Refuel(double.Parse(command[2]));
                                break;
                        }
                    }
                }
                else if (command[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(command[2]));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
