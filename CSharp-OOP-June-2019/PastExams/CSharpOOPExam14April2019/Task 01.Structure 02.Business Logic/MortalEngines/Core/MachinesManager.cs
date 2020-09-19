using System.Collections.Generic;
using System.Linq;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly IList<IMachine> machines;
        private readonly IList<IPilot> pilots;

        public MachinesManager()
        {
            machines = new List<IMachine>();
            pilots = new List<IPilot>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            var pilotToAdd = new Pilot(name);
            pilots.Add(pilotToAdd);
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            var tankToAdd = new Tank(name, attackPoints, defensePoints);
            machines.Add(tankToAdd);
            return $"Tank {name} manufactured - attack: {tankToAdd.AttackPoints:F2}; defense: {tankToAdd.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            var fighterToAdd = new Fighter(name, attackPoints, defensePoints);
            machines.Add(fighterToAdd);
            return $"Fighter {name} manufactured - attack: {fighterToAdd.AttackPoints:F2}; defense: {fighterToAdd.DefensePoints:F2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var selectedPilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            var selectedMachine = machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (selectedPilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (selectedMachine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (selectedMachine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilots.Remove(pilots.FirstOrDefault(x => x.Name == selectedPilotName));
            machines.Remove(machines.FirstOrDefault(x => x.Name == selectedMachineName));
            selectedPilot.AddMachine(selectedMachine);
            selectedMachine.Pilot = selectedPilot;
            pilots.Add(selectedPilot);
            machines.Add(selectedMachine);
            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            machines.Remove(machines.FirstOrDefault(x => x.Name == attackingMachineName));
            machines.Remove(machines.FirstOrDefault(x => x.Name == defendingMachineName));
            attackingMachine.Attack(defendingMachine);
            machines.Add(attackingMachine);
            machines.Add(defendingMachine);
            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            var reportingPilot = pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return reportingPilot == null ? $"Pilot {pilotReporting} could not be found" : reportingPilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var reportingMachine = machines.FirstOrDefault(x => x.Name == machineName);

            return reportingMachine == null ? $"Machine {machineName} could not be found" : reportingMachine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!(machines.FirstOrDefault(x => x.Name == fighterName) is Fighter fighterToToggle))
            {
                return $"Machine {fighterName} could not be found";
            }

            machines.Remove(machines.FirstOrDefault(x => x.Name == fighterName));
            fighterToToggle.ToggleAggressiveMode();
            machines.Remove(fighterToToggle);
            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!(machines.FirstOrDefault(x => x.Name == tankName) is Tank tankToToggle))
            {
                return $"Machine {tankName} could not be found";
            }

            machines.Remove(machines.FirstOrDefault(x => x.Name == tankName));
            tankToToggle.ToggleDefenseMode();
            machines.Add(tankToToggle);
            return $"Tank {tankName} toggled defense mode";
        }
    }
}