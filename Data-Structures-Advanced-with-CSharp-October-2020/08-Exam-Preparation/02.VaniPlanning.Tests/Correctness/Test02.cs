using NUnit.Framework;
using System;
using _02.VaniPlanning;

public class Test02
{
    [TestCase]
    public void CreateInvoice_With_Existing_Number_Should_Throw_Exception()
    {
        //Arrange

        var agency = new Agency();
        var invoice = new Invoice("first", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));
        var invoice2 = new Invoice("first", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));

        //Act

        agency.Create(invoice);

        //Assert

        Assert.Throws<ArgumentException>(() => agency.Create(invoice2));
    }
}
