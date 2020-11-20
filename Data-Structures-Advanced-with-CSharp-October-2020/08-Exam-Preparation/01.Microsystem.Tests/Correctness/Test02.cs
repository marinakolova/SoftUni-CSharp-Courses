using NUnit.Framework;
using System;
using _01.Microsystem;

public class Test02
{
    [TestCase]
    public void Create_Computer_Should_Throw_Exception_With_Existing_Id()
    {
        //Arrange

        var microsystems = new Microsystems();
        var computerValid = new Computer(1, Brand.ASUS, 1800, 14, "black");
        var invalidComputer = new Computer(1, Brand.ASUS, 1800, 14, "black");

        //Act

        microsystems.CreateComputer(computerValid);

        //Arrange

        Assert.Throws<ArgumentException>(() => microsystems.CreateComputer(invalidComputer));
    }
}
