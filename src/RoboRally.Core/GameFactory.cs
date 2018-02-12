using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    class GameFactory: IGameFactory
    {
		private readonly ICardDeckFactory _cardDeckFactory;

		public GameFactory(ICardDeckFactory cardDeckFactory)
		{
			_cardDeckFactory = cardDeckFactory;
		}

		public IGame Create(IPlayer[] players)
		{
			return new Game(_cardDeckFactory, players);
		}
	}
}
