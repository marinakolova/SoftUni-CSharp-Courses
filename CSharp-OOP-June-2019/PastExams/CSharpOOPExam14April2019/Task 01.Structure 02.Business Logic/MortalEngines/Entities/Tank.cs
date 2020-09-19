using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private bool defenseMode;
        private const double TankInitialHealthPoints = 100d;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, TankInitialHealthPoints)
        {
            DefenseMode = true;
        }

        public bool DefenseMode
        {
            get => defenseMode;
            private set
            {
                if (value == true)
                {
                    AttackPoints -= 40;
                    DefensePoints += 30;
                }
                else
                {
                    AttackPoints += 40;
                    DefensePoints -= 30;
                }
                defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            DefenseMode = !DefenseMode;
        }

        public override string ToString()
        {
            var defenseModeState = DefenseMode ? " *Defense: ON" : " *Defense: OFF";

            return base.ToString() + Environment.NewLine + defenseModeState;
        }
    }
}
