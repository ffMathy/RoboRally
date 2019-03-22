using RoboRally.Core.Cards;
using System;

namespace RoboRally.Core
{
    [Serializable]
    class GameFactory: IGameFactory
    {
		private readonly ICardDeckFactory _cardDeckFactory;
		private readonly IPlayerFactory _playerFactory;

        public GameFactory(
			ICardDeckFactory cardDeckFactory,
			IPlayerFactory playerFactory,
            IActionStepper actionStepper)
		{
			_cardDeckFactory = cardDeckFactory;
			_playerFactory = playerFactory;
        }

		public IGame Create(int playerCount)
		{
			return new Game(
                _cardDeckFactory, 
                _playerFactory, 
                new ActionStepper(),
                playerCount);
		}
	}
}
