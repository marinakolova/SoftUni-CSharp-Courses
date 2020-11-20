using _01.Microsystem;
using NUnit.Framework;

public class Test13
{
    [TestCase]
    public void Upgrade_Ram_Should_Not_Change_Ram()
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
        microsystems.UpgradeRam(4, 1);
        var expectedRam = 8;
        var actualRam = microsystems.GetComputer(1).RAM;

        //Assert

        Assert.AreEqual(expectedRam, actualRam);
    }
}
