using System;

namespace _08_Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split();
            var name = firstLine[0] + " " + firstLine[1];
            var address = firstLine[2];
            var town = firstLine[3];
            var firstThreeuple = new Threeuple<string, string, string>(name, address, town);

            var secondLine = Console.ReadLine().Split();
            var name2 = secondLine[0];
            var littersOfBeer = int.Parse(secondLine[1]);
            var isDrunk = false;
            if (secondLine[2] == "drunk")
            {
                isDrunk = true;
            }
            var secondThreeuple = new Threeuple<string, int, bool>(name2, littersOfBeer, isDrunk);

            var thirdLine = Console.ReadLine().Split();
            var name3 = thirdLine[0];
            var accountBalance = double.Parse(thirdLine[1]);
            var bankName = thirdLine[2];
            var thirdThreeuple = new Threeuple<string, double, string>(name3, accountBalance, bankName);

            Console.WriteLine(firstThreeuple.ToString());
            Console.WriteLine(secondThreeuple.ToString());
            Console.WriteLine(thirdThreeuple.ToString());
        }
    }
}
