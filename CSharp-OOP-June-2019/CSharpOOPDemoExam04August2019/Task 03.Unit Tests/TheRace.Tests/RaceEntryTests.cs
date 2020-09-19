using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddRider_Should_AddSuccessfully()
        {
            //Arrange
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 60, 500);
            UnitRider unitRider = new UnitRider("Ivan", unitMotorcycle);

            //Act
            string actualMessage = raceEntry.AddRider(unitRider);

            //Assert
            string expectedMessage = "Rider Ivan added in race.";

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(raceEntry.Counter, 1);
        }

        [Test]
        public void AddRider_Should_ThrowInvalidOperationExceptionIfNull()
        {
            //Arrange
            RaceEntry raceEntry = new RaceEntry();

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null));

            string expectedMessage = "Rider cannot be null.";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void AddRider_Should_ThrowInvalidOperationExceptionIfRiderAlreadyExists()
        {
            //Arrange
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 60, 500);
            UnitRider unitRider = new UnitRider("Ivan", unitMotorcycle);

            //Act
            string actualMessage = raceEntry.AddRider(unitRider);

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider));

            string expectedMessage = "Rider Ivan is already added.";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void CalculateAverageHorsePower_Should_ReturnAverageHorsePowerOfAllRiders()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Honda", 60, 500);
            UnitRider unitRider1 = new UnitRider("Ivan", unitMotorcycle1);

            UnitMotorcycle unitMotorcycle2 = new UnitMotorcycle("Kawasaki", 24, 500);
            UnitRider unitRider2 = new UnitRider("Peter", unitMotorcycle2);

            UnitMotorcycle unitMotorcycle3 = new UnitMotorcycle("Yamaha", 78, 500);
            UnitRider unitRider3 = new UnitRider("Sam", unitMotorcycle3);

            raceEntry.AddRider(unitRider1);
            raceEntry.AddRider(unitRider2);
            raceEntry.AddRider(unitRider3);

            var result = raceEntry.CalculateAverageHorsePower();

            var expectedResult = 54;

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void CalculateAverageHorsePower_Should_ThrowInvalidOperationExceptionWhenRidersAreLessThanTwo()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Honda", 60, 500);
            UnitRider unitRider1 = new UnitRider("Ivan", unitMotorcycle1);

            raceEntry.AddRider(unitRider1);

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

            string expectedMessage = "The race cannot start with less than 2 participants.";

            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}