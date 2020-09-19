using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person[] persons;

        [SetUp]
        public void Setup()
        {
            persons = new Person[]
                {
                    new Person(1112134567, "Pesho"),
                    new Person(1011123456, "Gosho")
                };
            database = new ExtendedDatabase.ExtendedDatabase(persons);

        }

        [Test]
        public void TestIfPersonConstructorWorksCorrectly()
        {
            long expectedId = 1010105647;
            string expectedUserName = "Ivan";

            Person person = new Person(1010105647, "Ivan");

            Assert.AreEqual(expectedId, person.Id);
            Assert.AreEqual(expectedUserName, person.UserName);
        }

        [Test]
        public void TestIfDataBaseConstructorWorksCorrectly()
        {
            int expectedCount = 2;

            this.database = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestIfAddingWorksCorrectly()
        {
            int expectedCount = 3;

            Person person3 = new Person(1010105647, "Ivan");

            this.database.Add(person3);

            Assert.AreEqual(expectedCount, database.Count);

        }

        [Test]
        public void TestIfAddingWhenCapacityIsFull()
        {
            for (int i = 0; i < 14; i++)
            {
                this.database.Add(new Person(i, $"Name{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(1000, "Stamat"));
            });
        }

        [Test]
        public void TestIfAddingDuplicateUserName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(5000, "Gosho"));
            });
        }

        [Test]
        public void TestIfAddingDuplicateId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(1011123456, "Georgi"));
            });
        }

        [Test]
        public void TestIfRemoveWorksCorrectly()
        {
            this.database.Remove();
            Assert.AreEqual(1, this.database.Count);
        }

        [Test]
        public void TestRemoveWhenCountIsZero()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void TestFindByUserNAme()
        {

            Person person = new Person(1234, "Stamat");
            this.database.Add(person);
            this.database.FindByUsername("Stamat");
            Assert.AreEqual(person,
                this.database.FindByUsername("Stamat"));
        }

        [Test]

        public void FindByUsername_Throws()

        {

            string username = string.Empty;

            Assert.That(() => database.FindByUsername(username),

                Throws.ArgumentNullException.With.Message.Contains("Username parameter is null!"));
        }

        [Test]
        public void TestFindByUserNameNonExistent()
        {

            Assert.That(() => database.FindByUsername("Any"),

                Throws.InvalidOperationException.With.Message.Contains("No user is present by this username!"));
        }

        [Test]
        public void TestFindByIdWorkingCorrectly()
        {
            Person person = new Person(1234, "Stamat");
            this.database.Add(person);

            Assert.AreEqual(person, this.database.FindById(1234));
        }

        [Test]
        public void TestFindByIdWithNegativeId()
        {
            Assert.That(() => database.FindById(-10),

                Throws.Exception.With.Message.Contains("Id should be a positive number!"));
        }

        [Test]
        public void TestFindByIdUsingInvalidId()
        {
            Assert.That(() => database.FindById(9999),

                Throws.InvalidOperationException.With.Message.Contains("No user is present by this ID!"));
        }
    }
}