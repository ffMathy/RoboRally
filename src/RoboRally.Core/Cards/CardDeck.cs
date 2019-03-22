using System;
using System.Collections.Generic;

namespace RoboRally.Core.Cards
{
    [Serializable]
    public class CardDeck : ICardDeck
    {
		private IList<ICard> _cards;

		public CardDeck(IList<ICard> cards)
		{
			_cards = cards;
		}

		public ICard TakeCard()
		{
			var card = _cards[0];
			_cards.Remove(card);
			return card;
		}

		public void ReturnCard(ICard card)
		{
			_cards.Add(card);
		}

		public void Shuffle()
		{
			var random = new Random();

			var shuffledCards = _cards;
			for (int n = shuffledCards.Count - 1; n > 0; --n)
			{
				int k = random.Next(n + 1);
				var temp = shuffledCards[n];
				shuffledCards[n] = shuffledCards[k];
				shuffledCards[k] = temp;
			}
			_cards = shuffledCards;
		}
    }
}
