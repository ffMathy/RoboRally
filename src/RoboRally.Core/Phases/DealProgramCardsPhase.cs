using System;

namespace RoboRally.Core.Phases
{
    [Serializable]
    public class DealProgramCardsPhase : IDealProgramCardsPhase
	{
		private const int CardsPerPlayer = 9;

		private readonly IGame _game;
        private readonly IActionStepper _actionStepper;

        public DealProgramCardsPhase(
            IGame game,
            IActionStepper actionStepper)
		{
			_game = game;
            _actionStepper = actionStepper;
        }

		public void Commit()
		{
			ShuffleDeck();
			DealCardsToPlayers();
		}

		private void ShuffleDeck()
		{
			_game.CardDeck.Shuffle();
		}

		private void DealCardsToPlayers()
		{
			foreach (var player in _game.Players)
			{
                player.Hand.Cards.Clear();
				for (var i = 0; i < CardsPerPlayer; i++)
				{
					player.Hand.Cards.Add(_game.CardDeck.TakeCard());
				}
			}
		}

        public bool Step()
        {
            return _actionStepper.Step(
                ShuffleDeck,
                DealCardsToPlayers);
        }
    }
}
