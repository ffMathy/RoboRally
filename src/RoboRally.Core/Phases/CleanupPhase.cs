using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
	class CleanupPhase : ICleanupPhase
	{
		private IGame _game;

		public CleanupPhase(IGame game)
		{
			_game = game;
		}

		public void Commit()
		{
			ReturnPlayerCards();
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
