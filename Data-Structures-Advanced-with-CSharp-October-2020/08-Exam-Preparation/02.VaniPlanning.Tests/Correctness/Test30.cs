using NUnit.Framework;
using System;
using _02.VaniPlanning;

public class Test30
{
    [TestCase]
    public void AddInvoice_Agency_Should_Contain_New_Invoice()
    {
        //Arrange

        var agency = new Agency();
        var invoice = new Invoice("first", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));

        //Act

        agency.Create(invoice);

        //Assert

        Assert.IsTrue(agency.Contains("first"));
    }
}
