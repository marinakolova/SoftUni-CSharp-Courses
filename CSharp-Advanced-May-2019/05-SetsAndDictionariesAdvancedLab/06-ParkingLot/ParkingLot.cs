using System;
using System.Collections.Generic;

namespace _06_ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            var parking = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var partsOfInput = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (partsOfInput[0] == "IN")
                {
                    parking.Add(partsOfInput[1]);
                }
                else if (partsOfInput[0] == "OUT")
                {
                    parking.Remove(partsOfInput[1]);
                }
            }

            if (parking.Count > 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
