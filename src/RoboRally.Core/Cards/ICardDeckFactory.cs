namespace RoboRally.Core.Cards
{
	public interface ICardDeckFactory
	{
		ICardDeck CreateDeck(IGame game);
	}
}