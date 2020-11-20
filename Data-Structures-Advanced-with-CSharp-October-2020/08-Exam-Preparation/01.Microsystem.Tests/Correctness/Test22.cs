using NUnit.Framework;
using System;
using _01.Microsystem;

public class Test22
{
    [TestCase]
    public void GetComputer_Should_Throw_Exception_With_Invalid_Number()
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

       
        //Assert

        Assert.Throws<ArgumentException>(() => microsystems.GetComputer(13));
       
    }
}
