using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int PistolBulletsPerBarrel = 10;
        private const int PistolTotalBullets = 100 - 10;
        private const int PistolShootingBulletsCount = 1;

        public Pistol(string name) 
            : base(name, PistolBulletsPerBarrel, PistolTotalBullets)
        {
        }
        
        public override int Fire()
        {
            if (PistolShootingBulletsCount > BulletsPerBarrel)
            {
                BulletsPerBarrel += BarrelCapacity;
                TotalBullets -= BarrelCapacity;
            }

            BulletsPerBarrel -= PistolShootingBulletsCount;
            return PistolShootingBulletsCount;
        }
    }
}
