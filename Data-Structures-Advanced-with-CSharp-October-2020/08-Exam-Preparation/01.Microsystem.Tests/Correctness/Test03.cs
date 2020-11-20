using _01.Microsystem;
using NUnit.Framework;

public class Test03
{
    [TestCase]
    public void Contains_Should_Return_True_With_Valid_Number()
    {
        //Arrange

        var microsystems = new Microsystems();
        var computer = new Computer(1, Brand.DELL, 2300,15.6, "grey");

        //Act
        microsystems.CreateComputer(computer);

        //Assert

        Assert.IsTrue(microsystems.Contains(1));
    }
}
