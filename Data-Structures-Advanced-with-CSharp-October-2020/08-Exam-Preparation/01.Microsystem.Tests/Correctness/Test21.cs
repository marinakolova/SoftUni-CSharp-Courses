using _01.Microsystem;
using NUnit.Framework;

public class Test21
{
    [TestCase]
    public void GetComputer_Should_Return_Correct_Computer()
    {
        //Arrange

        var microsystems = new Microsystems();
        var computer = new Computer(1, Brand.DELL, 2300, 15.6, "grey");
        var computer2 = new Computer(3, Brand.DELL, 2300, 15.6, "grey");
        var computer3 = new Computer(4, Brand.DELL, 2300, 15.6, "grey");

        //Act
        microsystems.CreateComputer(computer);
        microsystems.CreateComputer(computer2);
        microsystems.CreateComputer(computer3);

        var expectedNumber = 3;
        var expectedBrand = Brand.DELL;
        var actualNumber = microsystems.GetComputer(3).Number;
        var actualBrand = microsystems.GetComputer(3).Brand;

        //Assert

        Assert.AreEqual(expectedNumber, actualNumber);
        Assert.AreEqual(expectedBrand, actualBrand);

    }
}
