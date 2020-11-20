using NUnit.Framework;
using System;
using System.Linq;
using _02.VaniPlanning;

public class Test15
{
    [TestCase]
    public void GetAllInvoiceInPeriod_Should_Return_Empty_Collection_With_Invalid_Period()
    {
        //Arrange

        var agency = new Agency();
        var invoice = new Invoice("first", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 28), new DateTime(2001, 10, 28));
        var invoice2 = new Invoice("second", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 29), new DateTime(2001, 10, 28));
        var invoice3 = new Invoice("third", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 30), new DateTime(2001, 10, 28));
        var invoice4 = new Invoice("fourth", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));
        var invoice5 = new Invoice("fifth", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 11, 28), new DateTime(2001, 10, 28));


        //Act

        agency.Create(invoice);
        agency.Create(invoice2);
        agency.Create(invoice3);
        agency.Create(invoice4);
        agency.Create(invoice5);
        var expected = Enumerable.Empty<Invoice>();
        var actual = agency.GetAllInvoiceInPeriod(new DateTime(2001, 11, 28), new DateTime(2003, 12, 30));


        //Assert

        Assert.IsTrue(actual.SequenceEqual(expected));
    }
}
