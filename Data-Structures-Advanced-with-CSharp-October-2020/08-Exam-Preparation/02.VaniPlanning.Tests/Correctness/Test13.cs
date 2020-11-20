using NUnit.Framework;
using System;
using System.Linq;
using _02.VaniPlanning;

public class Test13
{
    [TestCase]
    public void GetAllInvoiceInPeriod_Should_Return_Correct_Count()
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
        var expectedCount = 4;
        var actual = agency.GetAllInvoiceInPeriod(new DateTime(2000, 11, 28), new DateTime(2000, 12, 30));
        var actualCount = actual.Count();

        //Assert

        Assert.AreEqual(expectedCount, actualCount);
    }
}
