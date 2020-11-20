using NUnit.Framework;
using System;
using _01.Microsystem;

public class Test10
{
    [TestCase]
    public void Remove_With_Non_Existing_Brand_Should_Throw_Exception()
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

        Assert.Throws<ArgumentException>(() => microsystems.RemoveWithBrand(Brand.HP));
    }
}
