namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;
    using Wintellect.PowerCollections;

    public class Legion : IArmy
    {
        private OrderedSet<IEnemy> _enemies;

        public Legion()
        {
            this._enemies = new OrderedSet<IEnemy>();
        }

        public int Size
            => this._enemies.Count;

        public bool Contains(IEnemy enemy)
        {
            return this._enemies.Contains(enemy);
        }

        public void Create(IEnemy enemy)
        {
            this._enemies.Add(enemy);
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            for (int i = 0; i < this.Size; i++)
            {
                var current = this._enemies[i];

                if (current.AttackSpeed == speed)
                {
                    return current;
                }
            }

            return null;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var faster = new List<IEnemy>(this.Size);

            foreach (var enemy in this._enemies)
            {
                if (enemy.AttackSpeed > speed)
                {
                    faster.Add(enemy);
                }
            }

            return faster;
        }

        public IEnemy GetFastest()
        {
            this.EnsureNotEmpty();
            return this._enemies.GetFirst();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            return this._enemies
                .OrderByDescending(x => x.Health)
                .ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var slower = new List<IEnemy>(this.Size);

            foreach (var enemy in this._enemies)
            {
                if (enemy.AttackSpeed < speed)
                {
                    slower.Add(enemy);
                }
            }

            return slower;
        }

        public IEnemy GetSlowest()
        {
            this.EnsureNotEmpty();
            return this._enemies.GetLast();
        }

        public void ShootFastest()
        {
            this.EnsureNotEmpty();
            this._enemies.RemoveFirst();
        }

        public void ShootSlowest()
        {
            this.EnsureNotEmpty();
            this._enemies.RemoveLast();
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
