using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int MainPlayerInitialLifePoints = 100;
        private const string MainPlayerName = "Tommy Vercetti";

        public MainPlayer() 
            : base(MainPlayerName, MainPlayerInitialLifePoints)
        {
        }
    }
}
