using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                var gunToShootWith = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.TotalBullets + x.BulletsPerBarrel > 0);

                if (gunToShootWith == null)
                {
                    break;
                }

                var civilPlayerToShootAt = civilPlayers.FirstOrDefault(x => x.IsAlive);

                if (civilPlayerToShootAt == null)
                {
                    break;
                }

                civilPlayerToShootAt.TakeLifePoints(gunToShootWith.Fire());
            }

            while (true)
            {
                if (!mainPlayer.IsAlive)
                {
                    break;
                }

                var civilPlayerToShoot = civilPlayers.Where(x => x.IsAlive)
                    .FirstOrDefault(x => x.GunRepository.Models.Any(y => y.TotalBullets + y.BulletsPerBarrel > 0));

                var gunToShootWith = civilPlayerToShoot?.GunRepository.Models.FirstOrDefault(y => y.TotalBullets + y.BulletsPerBarrel > 0);

                if (gunToShootWith == null)
                {
                    break;
                }

                mainPlayer.TakeLifePoints(gunToShootWith.Fire());
            }
        }
    }
}
