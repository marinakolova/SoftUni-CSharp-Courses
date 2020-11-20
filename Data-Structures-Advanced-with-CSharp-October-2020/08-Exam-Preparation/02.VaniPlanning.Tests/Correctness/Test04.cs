using NUnit.Framework;
using System;
using _02.VaniPlanning;

public class Test04
{
    [TestCase]
    public void Contains_Should_Return_False_With_Invalid_Number()
    {
        //Arrange

        var agency = new Agency();
        var invoice = new Invoice("first", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));


        //Act

        agency.Create(invoice);

        //Assert

        Assert.IsFalse(agency.Contains("second"));
    }
}
