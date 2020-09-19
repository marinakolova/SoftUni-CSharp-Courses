using System;

namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            softPark = new SoftPark();
        }

        [Test]
        public void Test_Constructor_InitializesTwelveParkingSpots()
        {
            var expected = 12;
            var actual = softPark.Parking.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_ParkCarOnInvalidSpot_Throws()
        {
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A5", new Car("Renault", "CB1234")));
        }

        [Test]
        public void Test_ParkCarOnTakenSpot_Throws()
        {
            softPark.ParkCar("A1", new Car("Audi", "CB5678"));
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A1", new Car("Renault", "CB1234")));
        }

        [Test]
        public void Test_ParkExistingCar_Throws()
        {
            var car = new Car("Audi", "CB5678");
            softPark.ParkCar("A1", car);
            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("A2", car));
        }

        [Test]
        public void Test_ParkCar_WorksCorrectly()
        {
            var car = new Car("Audi", "CB5678");

            var expected = $"Car:{car.RegistrationNumber} parked successfully!";

            var actual = softPark.ParkCar("A1", car);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_RemoveCarFromInvalidSpot_Throws()
        {
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A5", new Car("Renault", "CB1234")));
        }


        [Test]
        public void Test_RemoveInvalidCar_Throws()
        {
            softPark.ParkCar("A1", new Car("Audi", "CB5678"));

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A1", new Car("Renault", "CB1234")));
        }

        [Test]
        public void Test_RemoveCar_WorksCorrectly()
        {
            var car = new Car("Audi", "CB5678");
            softPark.ParkCar("A1", car);

            var expected = $"Remove car:{car.RegistrationNumber} successfully!";

            var actual = softPark.RemoveCar("A1", car);

            Assert.AreEqual(expected, actual);
        }
    }
}