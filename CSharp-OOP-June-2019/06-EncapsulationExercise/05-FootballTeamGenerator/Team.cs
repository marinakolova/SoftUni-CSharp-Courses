using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value == null || value == "" || value == " ")
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (this.players.Where(p => p.Name == playerName).FirstOrDefault() == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(this.players.Where(p => p.Name == playerName).FirstOrDefault());
        }

        public double GetRating()
        {
            double teamRating = 0;
            foreach (var player in this.players)
            {
                teamRating += player.GetSkillLevel();
            }
            return teamRating;
        }

        public override string ToString()
        {
            return $"{this.Name} - {Math.Round(this.GetRating())}";
        }
    }
}
