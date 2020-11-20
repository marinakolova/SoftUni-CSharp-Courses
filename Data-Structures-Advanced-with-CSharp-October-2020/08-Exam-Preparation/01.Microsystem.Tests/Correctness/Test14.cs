using NUnit.Framework;
using System;
using _01.Microsystem;

public class Test14
{
    [TestCase]
    public void Upgrade_Ram_Should_Throw_Exception_With_Invalid_Number()
    {
        //Arrange

        var microsystems = new Microsystems();
        var computer = new Computer(1, Brand.DELL, 2300, 15.6, "grey");
        var computer2 = new Computer(3, Brand.DELL, 2300, 15.6, "grey");
        var computer3 = new Computer(4, Brand.DELL, 2300, 15.6, "grey");
        var computer4 = new Computer(5, Brand.ACER, 2300, 15.6, "grey");

        //Act
        microsystems.CreateComputer(computer);
        microsystems.CreateComputer(computer2);
        microsystems.CreateComputer(computer3);
        microsystems.CreateComputer(computer4);

        //Assert

        Assert.Throws<ArgumentException>(()=>microsystems.UpgradeRam(16, 12));
    }
}
