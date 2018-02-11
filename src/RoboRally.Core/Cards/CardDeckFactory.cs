using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{

	public class CardDeckFactory : ICardDeckFactory
	{

		private IDictionary<Move, List<int>> cards;

		public ICardDeck CreateDeck()
		{
			throw new NotImplementedException();
		}
    }
}
