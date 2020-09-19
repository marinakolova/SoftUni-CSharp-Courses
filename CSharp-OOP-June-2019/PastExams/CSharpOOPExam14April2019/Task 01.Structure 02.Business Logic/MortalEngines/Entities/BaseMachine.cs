using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            Name = name;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            HealthPoints = healthPoints;
            Targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Machine name cannot be null or empty.");
                }
                name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;
            set => pilot = value ?? throw new NullReferenceException("Pilot cannot be null.");
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            if (target.HealthPoints >= (AttackPoints - target.DefensePoints))
            {
                target.HealthPoints -= (AttackPoints - target.DefensePoints);
            }
            else
            {
                target.HealthPoints = 0;
            }

            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Health: {HealthPoints:F2}");
            sb.AppendLine($" *Attack: {AttackPoints:F2}");
            sb.AppendLine($" *Defense: {DefensePoints:F2}");
            sb.Append(" *Targets: ");
            sb.Append(Targets.Count > 0 ? string.Join(",", Targets) : "None");

            return sb.ToString();
        }
    }
}
