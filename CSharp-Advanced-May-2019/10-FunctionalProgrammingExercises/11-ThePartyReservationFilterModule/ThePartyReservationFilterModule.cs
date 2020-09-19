using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var filters = new List<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Print")
                {
                    break;
                }

                var partsOfCommand = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                switch (partsOfCommand[0])
                {
                    case "Add filter":
                        filters.Add(partsOfCommand[1] + " " + partsOfCommand[2]);
                        break;

                    case "Remove filter":
                        filters.Remove(partsOfCommand[1] + " " + partsOfCommand[2]);
                        break;
                }
            }

            foreach (var filter in filters)
            {
                var conditions = filter.Split(" ");

                switch (conditions[0])
                {
                    case "Starts":
                        guests = guests.Where(p => !p.StartsWith(conditions[2])).ToList();
                        break;

                    case "Ends":
                        guests = guests.Where(p => !p.EndsWith(conditions[2])).ToList();
                        break;

                    case "Length":
                        guests = guests.Where(p => p.Length != int.Parse(conditions[1])).ToList();
                        break;

                    case "Contains":
                        guests = guests.Where(p => !p.Contains(conditions[1])).ToList();
                        break;
                }
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
    }
}
