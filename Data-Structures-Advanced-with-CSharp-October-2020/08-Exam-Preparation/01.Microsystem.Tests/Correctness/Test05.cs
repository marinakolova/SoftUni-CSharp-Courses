using _01.Microsystem;
using NUnit.Framework;

public class Test05
{
    [TestCase]
    public void Count_Should_Work_Correct()
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

        Assert.AreEqual(3, microsystems.Count());
    }
}
