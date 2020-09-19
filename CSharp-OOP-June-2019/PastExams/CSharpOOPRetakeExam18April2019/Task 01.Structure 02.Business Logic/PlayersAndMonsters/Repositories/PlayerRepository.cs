using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDictionary<string, IPlayer> playersByName;

        public PlayerRepository()
        {
            playersByName = new Dictionary<string, IPlayer>();
        }

        public int Count => playersByName.Count;

        public IReadOnlyCollection<IPlayer> Players => playersByName.Values.ToList();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            playersByName.Add(player.Username, player);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            bool isRemoved = playersByName.Remove(player.Username);

            return isRemoved;
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;

            if (playersByName.ContainsKey(username))
            {
                player = playersByName[username];
            }

            return player;

        }
    }
}
