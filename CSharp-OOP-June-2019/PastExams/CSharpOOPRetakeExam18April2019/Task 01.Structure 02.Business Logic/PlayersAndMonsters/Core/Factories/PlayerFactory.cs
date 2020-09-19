using System;
using System.Linq;
using System.Reflection;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type playerType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IPlayer player = (IPlayer)Activator.CreateInstance(playerType ?? throw new ArgumentException(), new CardRepository(), username);

            return player;
        }
    }
}
