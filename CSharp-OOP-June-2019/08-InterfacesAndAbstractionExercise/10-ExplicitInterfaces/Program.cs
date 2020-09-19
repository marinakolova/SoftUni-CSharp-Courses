using System;

namespace _10_ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var citizenData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = citizenData[0];
                var country = citizenData[1];
                var age = int.Parse(citizenData[2]);

                var citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
