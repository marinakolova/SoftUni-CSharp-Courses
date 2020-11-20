using _01.Microsystem;
using NUnit.Framework;

public class Test04
{
    [TestCase]
    public void Contains_Should_Return_False_With_Invalid_Number()
    {
        //Arrange

        var microsystems = new Microsystems();
        var computer = new Computer(1, Brand.DELL, 2300, 15.6, "grey");

        //Act
        microsystems.CreateComputer(computer);

        //Assert

        Assert.IsFalse(microsystems.Contains(3));
    }
}
