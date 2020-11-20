using _01.Microsystem;
using NUnit.Framework;

public class Test11
{
    [TestCase]
    public void Remove_With_Brand_Should_Not_Contain_Removed_Computers()
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
        microsystems.RemoveWithBrand(Brand.DELL);


        //Assert

        Assert.IsFalse(microsystems.Contains(1));
        Assert.IsFalse(microsystems.Contains(3));
        Assert.IsFalse(microsystems.Contains(4));
    }
}
