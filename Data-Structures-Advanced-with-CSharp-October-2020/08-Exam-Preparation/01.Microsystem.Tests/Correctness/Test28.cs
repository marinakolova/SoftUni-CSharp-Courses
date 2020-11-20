using NUnit.Framework;
using System.Collections.Generic;
using _01.Microsystem;

public class Test28
{
    [TestCase]
    public void GetInRangePrice_Should_Return_Correct_Order()
    {
        //Arrange

        var microsystems = new Microsystems();
        var computer = new Computer(7, Brand.DELL, 2400, 15.6, "grey");
        var computer2 = new Computer(3, Brand.DELL, 2200, 15.6, "blue");
        var computer3 = new Computer(6, Brand.DELL, 2800, 15.6, "grey");
        var computer4 = new Computer(5, Brand.ACER, 2500, 15.6, "grey");

        //Act
        microsystems.CreateComputer(computer);
        microsystems.CreateComputer(computer2);
        microsystems.CreateComputer(computer3);
        microsystems.CreateComputer(computer4);
        var expected = new List<Computer>()
        {
            new Computer(5, Brand.ACER, 2500, 15.6, "grey"),
            new Computer(7, Brand.DELL, 2400, 15.6, "grey"),
            new Computer(3, Brand.DELL, 2200, 15.6, "blue")

    };
        var actual = microsystems.GetInRangePrice(2200, 2500);

        //Assert

        CollectionAssert.AreEqual(expected, actual);
    }
}
