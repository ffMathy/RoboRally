using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
	class CleanupPhase : ICleanupPhase
	{
		private readonly IGame _game;
        private readonly IActionStepper _actionStepper;

        public CleanupPhase(
            IGame game,
            IActionStepper actionStepper)
		{
			_game = game;
            _actionStepper = actionStepper;
        }

        public bool Step()
        {
            return _actionStepper.Step(
                ReturnPlayerCards);
        }

        private void ReturnPlayerCards()
		{
			foreach (var player in _game.Players)
			{
				foreach(var card in player.Hand.Cards)
				{
					_game.CardDeck.ReturnCard(card);
				}
				player.Hand.Cards.Clear();
			}
		}
	}
}
