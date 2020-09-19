namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void Test_Constructor_WorksCorrectly()
        {
            var spaceship = new Spaceship("Apolo", 11);

            var expected = 0;
            var actual = spaceship.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_NullName_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var spaceship = new Spaceship(null, 11);
            });
        }

        [Test]
        public void Test_NegativeCapacity_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var spaceship = new Spaceship("Apolo", -11);
            });
        }

        [Test]
        public void Test_AddWithFullCapacity_Throws()
        {
            var spaceship = new Spaceship("Apolo", 1);
            spaceship.Add(new Astronaut("Pesho", 100));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Gosho", 100)));
        }

        [Test]
        public void Test_AddExistingAstronaut_Throws()
        {
            var spaceship = new Spaceship("Apolo", 2);
            spaceship.Add(new Astronaut("Pesho", 100));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Pesho", 100)));
        }

        [Test]
        public void Test_Add_WorksCorrectly()
        {
            var spaceship = new Spaceship("Apolo", 2);
            spaceship.Add(new Astronaut("Pesho", 100));
            spaceship.Add(new Astronaut("Gosho", 100));

            var expected = 2;
            var actual = spaceship.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Remove_WorksCorrectly()
        {
            var spaceship = new Spaceship("Apolo", 2);
            spaceship.Add(new Astronaut("Pesho", 100));

            var expected = true;

            var actual = spaceship.Remove("Pesho");

            Assert.AreEqual(expected, actual);
        }
    }
}