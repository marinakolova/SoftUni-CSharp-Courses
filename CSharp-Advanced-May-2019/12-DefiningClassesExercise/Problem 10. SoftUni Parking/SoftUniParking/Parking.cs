using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count
        {
            get { return cars.Count; }
        }

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (this.cars.Where(x => x.RegistrationNumber == car.RegistrationNumber).ToList().Count > 0)
            {
                return "Car with that registration number, already exists!";
            }

            else if (this.cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            else
            {
                this.cars.Add(car);

                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.cars.Where(x => x.RegistrationNumber == registrationNumber).ToList().Count > 0)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);

                return $"Successfully removed {registrationNumber}";
            }

            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault();
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                if (this.cars.Where(x => x.RegistrationNumber == number).ToList().Count > 0)
                {
                    this.cars.RemoveAll(x => x.RegistrationNumber == number);
                }
            }
        }
    }
}
