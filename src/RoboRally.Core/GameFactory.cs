using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    class GameFactory: IGameFactory
    {
		private readonly ICardDeckFactory _cardDeckFactory;
		private readonly IPlayerFactory _playerFactory;

		public GameFactory(
			ICardDeckFactory cardDeckFactory,
			IPlayerFactory playerFactory)
		{
			_cardDeckFactory = cardDeckFactory;
			_playerFactory = playerFactory;
		}

		public IGame Create(int playerCount)
		{
			return new Game(_cardDeckFactory, _playerFactory, playerCount);
		}
	}
}
