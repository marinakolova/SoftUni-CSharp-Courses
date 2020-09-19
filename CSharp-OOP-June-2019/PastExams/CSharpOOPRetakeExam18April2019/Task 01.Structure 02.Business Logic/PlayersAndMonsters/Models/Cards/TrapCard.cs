namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int TrapCardDamagePoints = 120;
        private const int TrapCardHealthPoints = 5;

        public TrapCard(string name) 
            : base(name, TrapCardDamagePoints, TrapCardHealthPoints)
        {
        }
    }
}
