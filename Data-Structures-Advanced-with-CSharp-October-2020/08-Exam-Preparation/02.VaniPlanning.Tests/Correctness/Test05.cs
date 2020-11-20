using NUnit.Framework;
using System;
using _02.VaniPlanning;

public class Test05
{
    [TestCase]
    public void Count_Should_Work_Correct()
    {
        //Arrange

        var agency = new Agency();
        var invoice = new Invoice("first", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));
        var invoice2 = new Invoice("second", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));
        var invoice3 = new Invoice("third", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));


        //Act

        agency.Create(invoice);
        agency.Create(invoice2);
        agency.Create(invoice3);
        var expectedCount = 3;
        var actualCount = agency.Count();

        //Assert

        Assert.AreEqual(expectedCount, actualCount);
    }
}
