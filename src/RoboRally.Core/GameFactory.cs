using RoboRally.Core.Cards;

namespace RoboRally.Core
{
    class GameFactory: IGameFactory
    {
		private readonly ICardDeckFactory _cardDeckFactory;
		private readonly IPlayerFactory _playerFactory;
        private readonly IActionStepper _actionStepper;

        public GameFactory(
			ICardDeckFactory cardDeckFactory,
			IPlayerFactory playerFactory,
            IActionStepper actionStepper)
		{
			_cardDeckFactory = cardDeckFactory;
			_playerFactory = playerFactory;
            _actionStepper = actionStepper;
        }

		public IGame Create(int playerCount)
		{
			return new Game(
                _cardDeckFactory, 
                _playerFactory, 
                _actionStepper,
                playerCount);
		}
	}
}
