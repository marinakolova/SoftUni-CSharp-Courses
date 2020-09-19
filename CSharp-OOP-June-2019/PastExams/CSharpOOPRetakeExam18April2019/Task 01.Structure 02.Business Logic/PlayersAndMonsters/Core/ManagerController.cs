using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    using Contracts;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerFactory playerFactory;
        private readonly ICardFactory cardFactory;
        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;
        private readonly IBattleField battleField;

        public ManagerController(IPlayerFactory playerFactory, IPlayerRepository playerRepository, 
            ICardFactory cardFactory, ICardRepository cardRepository,
            IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);
            playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepository.Find(username);
            var card = cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = playerRepository.Find(attackUser);
            var enemyPlayer = playerRepository.Find(enemyUser);

            battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                if (player.CardRepository.Count > 0)
                {
                    foreach (var card in player.CardRepository.Cards)
                    {
                        sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                    }
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
