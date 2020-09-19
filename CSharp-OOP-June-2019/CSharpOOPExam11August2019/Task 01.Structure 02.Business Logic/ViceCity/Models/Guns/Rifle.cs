using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int RifleBulletsPerBarrel = 50;
        private const int RifleTotalBullets = 500 - 50;
        private const int RifleShootingBulletsCount = 5;

        public Rifle(string name) 
            : base(name, RifleBulletsPerBarrel, RifleTotalBullets)
        {
        }

        public override int Fire()
        {
            if (RifleShootingBulletsCount > BulletsPerBarrel)
            {
                BulletsPerBarrel += BarrelCapacity;
                TotalBullets -= BarrelCapacity;
            }

            BulletsPerBarrel -= RifleShootingBulletsCount;
            return RifleShootingBulletsCount;
        }
    }
}
