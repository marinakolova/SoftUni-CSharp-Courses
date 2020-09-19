using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly IList<IPlayer> civilPlayers;
        private readonly Queue<IGun> guns;
        private readonly INeighbourhood gangNeighbourhood;

        public Controller()
        {
            mainPlayer = new MainPlayer();
            civilPlayers = new List<IPlayer>();
            guns = new Queue<IGun>();
            gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            var playerToAdd = new CivilPlayer(name);
            civilPlayers.Add(playerToAdd);

            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            if (type == "Pistol")
            {
                var pistolToAdd = new Pistol(name);
                guns.Enqueue(pistolToAdd);
                return $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                var rifleToAdd = new Rifle(name);
                guns.Enqueue(rifleToAdd);
                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
            
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                var gunToAdd = guns.Dequeue();
                mainPlayer.GunRepository.Add(gunToAdd);
                return $"Successfully added {gunToAdd.Name} to the Main Player: Tommy Vercetti";
            }

            if (civilPlayers.All(x => x.Name != name))
            {
                return "Civil player with that name doesn't exists!";
            }

            var playerToAddGunTo = civilPlayers.FirstOrDefault(x => x.Name == name);
            var gunToAddToCivilPlayer = guns.Dequeue();
            playerToAddGunTo?.GunRepository.Add(gunToAddToCivilPlayer);
            return $"Successfully added {gunToAddToCivilPlayer.Name} to the Civil Player: {name}";
        }

        public string Fight()
        {
            var mainPlayerPointsAtBegining = mainPlayer.LifePoints;
            var civilPlayersPointsAtBegining = civilPlayers.Sum(x => x.LifePoints);

            gangNeighbourhood.Action(mainPlayer, civilPlayers);

            var civilPlayersPointsAtTheEnd = civilPlayers.Sum(x => x.LifePoints);
            
            if (mainPlayerPointsAtBegining == mainPlayer.LifePoints && civilPlayersPointsAtBegining == civilPlayersPointsAtTheEnd)
            {
                return "Everything is okay!";
            }

            var deadCivilPlayers = civilPlayers.Where(x => !x.IsAlive).ToList().Count;
            var leftCivilPlayers = civilPlayers.Where(x => x.IsAlive).ToList().Count;

            return "A fight happened:"
                   + Environment.NewLine
                   + $"Tommy live points: {mainPlayer.LifePoints}!"
                   + Environment.NewLine
                   + $"Tommy has killed: {deadCivilPlayers} players!"
                   + Environment.NewLine
                   + $"Left Civil Players: {leftCivilPlayers}!";
        }
    }
}
