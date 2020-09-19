using System;
using System.Linq;

namespace _10_PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> predicate;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                var partsOfCommand = command.Split();
                var action = partsOfCommand[0];
                var condition = partsOfCommand[1];
                var argument = partsOfCommand[2];

                predicate = GetDesiredExpression(condition, argument);

                if (action == "Double")
                {
                    var newGuests = guests.FindAll(predicate);

                    foreach (var guest in newGuests)
                    {
                        int indexOfGuest = guests.IndexOf(guest);
                        guests.Insert(indexOfGuest + 1, guest);
                    }
                }

                else if (action == "Remove")
                {
                    guests.RemoveAll(predicate);
                }


            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        public static Predicate<string> GetDesiredExpression(string condition, string argument)
        {
            if (condition == "StartsWith")
            {
                return p => p.StartsWith(argument);
            }

            if (condition == "EndsWith")
            {
                return p => p.EndsWith(argument);
            }

            if (condition == "Length")
            {
                return p => p.Length == int.Parse(argument);
            }

            return null;
        }
    }
}