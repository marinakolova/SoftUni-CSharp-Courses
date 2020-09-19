using System;
using System.ComponentModel.DataAnnotations;

namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Test_ConstructorWithNullMake_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var phone = new Phone(null, "A5");
            });
        }

        [Test]
        public void Test_ConstructorWithNullModel_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var phone = new Phone("Samsung", null);
            });
        }

        [Test]
        public void Test_Constructor_WorksCorrectly()
        {
            var phone = new Phone("Samsung", "A5");

            var expected = 0;

            var actual = phone.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_AddExistingContact_Throws()
        {
            var phone = new Phone("Samsung", "A5");
            phone.AddContact("Pesho", "0888123456");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "0888456789"));
        }

        [Test]
        public void Test_AddContact_WorksCorrectly()
        {
            var phone = new Phone("Samsung", "A5");
            phone.AddContact("Pesho", "0888123456");

            var expected = 1;

            var actual = phone.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CallInvalidContact_Throws()
        {
            var phone = new Phone("Samsung", "A5");
            phone.AddContact("Pesho", "0888123456");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }

        [Test]
        public void Test_Call_WorksCorrectly()
        {
            var phone = new Phone("Samsung", "A5");
            phone.AddContact("Pesho", "0888123456");

            var expected = $"Calling Pesho - 0888123456...";

            var actual = phone.Call("Pesho");

            Assert.AreEqual(expected, actual);
        }
    }
}