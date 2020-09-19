using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private bool aggressiveMode;
        private const double FighterInitialHealthPoints = 200d;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, FighterInitialHealthPoints)
        {
            AggressiveMode = true;
        }

        public bool AggressiveMode
        {
            get => aggressiveMode;
            private set
            {
                if (value == true)
                {
                    AttackPoints += 50;
                    DefensePoints -= 25;
                }
                else
                {
                    AttackPoints -= 50;
                    DefensePoints += 25;
                }
                aggressiveMode = value;
            }
        }

        public void ToggleAggressiveMode()
        {
            AggressiveMode = !AggressiveMode;
        }

        public override string ToString()
        {
            var aggressiveModeState = AggressiveMode ? " *Aggressive: ON" : " *Aggressive: OFF";

            return base.ToString() + Environment.NewLine + aggressiveModeState;
        }
    }
}
