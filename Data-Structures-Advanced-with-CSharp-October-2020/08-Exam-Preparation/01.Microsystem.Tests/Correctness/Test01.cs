using _01.Microsystem;
using NUnit.Framework;

public class Test01
{
    [TestCase]
    public void Create_Computer_Count_Should_Increase()
    {
        //Arrange

        var microsystems = new Microsystems();
        var computer1 = new Computer(1, Brand.ACER, 1120, 15.6, "grey");
        var computer2 = new Computer(2, Brand.ASUS, 2000, 15.6, "red");
        //Act

        var expectedCount = 2;
        microsystems.CreateComputer(computer1);
        microsystems.CreateComputer(computer2);
        var actualCount = microsystems.Count();

        //Assert
        Assert.AreEqual(expectedCount, actualCount);
    }
}
