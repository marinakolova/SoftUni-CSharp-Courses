using _01.Microsystem;
using NUnit.Framework;

public class Test06
{
    [TestCase]
    public void Remove_Should_Decrease_Count()
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

        Assert.AreEqual(2, microsystems.Count());
    }
}
