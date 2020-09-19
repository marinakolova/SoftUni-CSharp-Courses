using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            Name = name;
            LifePoints = lifePoints;
            GunRepository = new GunRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Player's name cannot be null or a whitespace!");
                }
                name = value;
            }
        }

        public bool IsAlive => LifePoints > 0;

        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (LifePoints >= points)
            {
                LifePoints -= points;
            }
            else
            {
                LifePoints = 0;
            }
        }
    }
}
