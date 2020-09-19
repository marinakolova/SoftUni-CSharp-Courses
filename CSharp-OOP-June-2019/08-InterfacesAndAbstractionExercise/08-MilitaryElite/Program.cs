using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            var soldiers = new List<Soldier>();
            var privates = new List<Private>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var typeOfSoldier = partsOfCommand[0];
                var id = int.Parse(partsOfCommand[1]);
                var firstName = partsOfCommand[2];
                var lastName = partsOfCommand[3];
                var salaryOrCodeNumber = partsOfCommand[4];

                switch (typeOfSoldier)
                {
                    case "Private":
                        var privateToAdd = new Private(id, firstName, lastName, decimal.Parse(salaryOrCodeNumber));
                        soldiers.Add(privateToAdd);
                        privates.Add(privateToAdd);
                        break;

                    case "LieutenantGeneral":
                        var lieutenantToAdd = new LieutenantGeneral(id, firstName, lastName, decimal.Parse(salaryOrCodeNumber));
                        for (int i = 5; i < partsOfCommand.Length; i++)
                        {
                            var privateId = int.Parse(partsOfCommand[i]);
                            lieutenantToAdd.PrivatesUnderCommand
                                .Add(privates.Where(x => x.Id == privateId).FirstOrDefault());
                        }
                        soldiers.Add(lieutenantToAdd);
                        break;

                    case "Engineer":
                        var corps = partsOfCommand[5];
                        if (corps == "Airforces" || corps == "Marines")
                        {
                            var engineerToAdd = new Engineer(id, firstName, lastName, decimal.Parse(salaryOrCodeNumber), corps);
                            for (int i = 6; i < partsOfCommand.Length - 1; i += 2)
                            {
                                var partName = partsOfCommand[i];
                                var hoursWorked = int.Parse(partsOfCommand[i + 1]);
                                engineerToAdd.Repairs.Add(new Repair(partName, hoursWorked));
                            }
                            soldiers.Add(engineerToAdd);
                        }
                        break;

                    case "Commando":
                        var corpsOfCommando = partsOfCommand[5];
                        if (corpsOfCommando == "Airforces" || corpsOfCommando == "Marines")
                        {
                            var commandoToAdd = new Commando(id, firstName, lastName, decimal.Parse(salaryOrCodeNumber), corpsOfCommando);
                            for (int i = 6; i < partsOfCommand.Length - 1; i += 2)
                            {
                                var codeName = partsOfCommand[i];
                                var state = partsOfCommand[i + 1];
                                if (state == "inProgress" || state == "Finished")
                                {
                                    commandoToAdd.Missions.Add(new Mission(codeName, state));
                                }
                            }
                            soldiers.Add(commandoToAdd);
                        }
                        break;

                    case "Spy":
                        var spyToAdd = new Spy(id, firstName, lastName, int.Parse(salaryOrCodeNumber));
                        soldiers.Add(spyToAdd);
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
