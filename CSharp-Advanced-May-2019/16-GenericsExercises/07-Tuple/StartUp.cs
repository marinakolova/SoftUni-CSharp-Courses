using System;

namespace _07_Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split();
            var name = firstLine[0] + " " + firstLine[1];
            var address = firstLine[2];
            var firstTuple = new Tuple<string, string>(name, address);

            var secondLine = Console.ReadLine().Split();
            var name2 = secondLine[0];
            var littersOfBeer = int.Parse(secondLine[1]);
            var secondTuple = new Tuple<string, int>(name2, littersOfBeer);

            var thirdLine = Console.ReadLine().Split();
            var integer = int.Parse(thirdLine[0]);
            var doubleNum = double.Parse(thirdLine[1]);
            var thirdTuple = new Tuple<int, double>(integer, doubleNum);

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
