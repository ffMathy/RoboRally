namespace RoboRally.Core.Cards
{
	public interface ICardDeck
	{
		ICard TakeCard();
		void ReturnCard(ICard card);
		void Shuffle();
	}
}