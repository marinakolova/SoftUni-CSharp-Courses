namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> _weapons;

        public Inventory()
        {
            this._weapons = new List<IWeapon>();
        }

        public int Capacity
            => this._weapons.Count;

        public void Add(IWeapon weapon)
        {
            this._weapons.Add(weapon);
        }

        public void Clear()
        {
            this._weapons.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return this._weapons.Contains(weapon);
        }

        public void EmptyArsenal(Category category)
        {
            foreach (var weapon in this._weapons)
            {
                if (weapon.Category == category)
                {
                    weapon.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            var indexOfWeapon = this._weapons.IndexOf(weapon);
            this.EnsureWeaponExists(indexOfWeapon);

            if (this._weapons[indexOfWeapon].Ammunition < ammunition)
            {
                return false;
            }

            this._weapons[indexOfWeapon].Ammunition -= ammunition;
            return true;
        }

        public IWeapon GetById(int id)
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var current = this._weapons[i];

                if (current.Id == id)
                {
                    return current;
                }
            }

            return null;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this._weapons.Count; i++)
            {
                yield return this._weapons[i];
            }
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            var indexOfWeapon = this._weapons.IndexOf(weapon);
            this.EnsureWeaponExists(indexOfWeapon);

            if (this._weapons[indexOfWeapon].Ammunition + ammunition 
                >= this._weapons[indexOfWeapon].MaxCapacity)
            {
                this._weapons[indexOfWeapon].Ammunition = this._weapons[indexOfWeapon].MaxCapacity;
            }
            else
            {
                this._weapons[indexOfWeapon].Ammunition += ammunition;
            }

            return this._weapons[indexOfWeapon].Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            IWeapon found = this.GetById(id);

            if (found == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            this._weapons.Remove(found);
            return found;
        }

        public int RemoveHeavy()
        {
            return this._weapons
                .RemoveAll(x => x.Category == Category.Heavy);
        }

        public List<IWeapon> RetrieveAll()
        {
            var all = new List<IWeapon>(this.Capacity);

            foreach (var weapon in this._weapons)
            {
                all.Add(weapon);
            }

            return all;
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var retrieved = new List<IWeapon>(this.Capacity);

            foreach (var weapon in this._weapons)
            {
                if (weapon.Category >= lower
                    && weapon.Category <= upper)
                {
                    retrieved.Add(weapon);
                }
            }

            return retrieved;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var indexOfFirst = this._weapons.IndexOf(firstWeapon);
            this.EnsureWeaponExists(indexOfFirst);
            var indexOfSecond = this._weapons.IndexOf(secondWeapon);
            this.EnsureWeaponExists(indexOfSecond);

            if (firstWeapon.Category == secondWeapon.Category)
            {
                var temp = this._weapons[indexOfFirst];
                this._weapons[indexOfFirst] = this._weapons[indexOfSecond];
                this._weapons[indexOfSecond] = temp;
            }
        }

        private void EnsureWeaponExists(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}
