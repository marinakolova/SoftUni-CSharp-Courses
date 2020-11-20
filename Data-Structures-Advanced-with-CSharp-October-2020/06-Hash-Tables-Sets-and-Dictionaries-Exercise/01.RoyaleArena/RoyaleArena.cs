namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> cardsById = new Dictionary<int, BattleCard>();

        public void Add(BattleCard card)
        {
            if (this.Contains(card))
            {
                return;
            }

            this.cardsById.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.cardsById.ContainsKey(card.Id);
        }

        public int Count 
        {
            get => this.cardsById.Count;
        }

        public void ChangeCardType(int id, CardType type)
        {
            if (!this.cardsById.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.cardsById[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            if (!this.cardsById.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.cardsById[id];
        }

        public void RemoveById(int id)
        {
            if (!this.cardsById.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.cardsById.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var found = this.cardsById.Values
                .Where(x => x.Type == type)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id)
                .ToList();

            if (found.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return found;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var found = this.cardsById.Values
                .Where(x => x.Type == type
                        && x.Damage > lo
                        && x.Damage < hi)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id)
                .ToList();

            if (found.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return found;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var found = this.cardsById.Values
                .Where(x => x.Type == type
                        && x.Damage <= damage)
                .OrderByDescending(x => x.Damage)
                .ThenBy(x => x.Id)
                .ToList();

            if (found.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return found;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var found = this.cardsById.Values
                .Where(x => x.Name == name)
                .OrderByDescending(x => x.Swag)
                .ThenBy(x => x.Id)
                .ToList();

            if (found.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return found;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var found = this.cardsById.Values
                .Where(x => x.Name == name
                        && x.Swag > lo
                        && x.Swag < hi)
                .OrderByDescending(x => x.Swag)
                .ThenBy(x => x.Id)
                .ToList();

            if (found.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return found;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.Count)
            {
                throw new InvalidOperationException();
            }

            return this.cardsById.Values
                .OrderBy(x => x.Swag)
                .Take(n)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            var found = this.cardsById.Values
                .Where(x => x.Swag >= lo
                        && x.Swag <= hi)
                .OrderBy(x => x.Swag)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<BattleCard>();
            }

            return found;
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            return this.cardsById.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}