using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IDictionary<string, ICard> cardsByName;

        public CardRepository()
        {
            cardsByName = new Dictionary<string, ICard>();
        }

        public int Count => cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards => cardsByName.Values.ToList();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            
            cardsByName.Add(card.Name, card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            bool isRemoved = cardsByName.Remove(card.Name);

            return isRemoved;
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (cardsByName.ContainsKey(name))
            {
                card = cardsByName[name];
            }

            return card;
        }
    }
}
