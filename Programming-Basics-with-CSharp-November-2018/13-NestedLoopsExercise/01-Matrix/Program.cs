using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int firstRowFirstNum = a; firstRowFirstNum <= b; firstRowFirstNum++)
            {
                for (int firstRowSecondNum = a; firstRowSecondNum <= b; firstRowSecondNum++)
                {
                    for (int secondRowFirstNum = c; secondRowFirstNum <= d; secondRowFirstNum++)
                    {
                        for (int secondRowSecondNum = c; secondRowSecondNum <= d; secondRowSecondNum++)
                        {
                            if (((firstRowFirstNum + secondRowSecondNum) == (firstRowSecondNum + secondRowFirstNum) && (firstRowFirstNum != firstRowSecondNum) && (secondRowFirstNum != secondRowSecondNum)))
                            {
                                Console.WriteLine($"{firstRowFirstNum}{firstRowSecondNum}");
                                Console.WriteLine($"{secondRowFirstNum}{secondRowSecondNum}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
