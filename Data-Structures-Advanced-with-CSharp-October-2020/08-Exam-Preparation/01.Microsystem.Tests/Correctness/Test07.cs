using NUnit.Framework;
using System;
using _01.Microsystem;

public class Test07
{
    [TestCase]
    public void Remove_Should_Throw_Exception_With_Invalid_Id()
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
        microsystems.Remove(1);

        //Assert

        Assert.Throws<ArgumentException>(() => microsystems.Remove(1));
    }
}
