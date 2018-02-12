using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
	public class DealProgramCardsPhase : IDealProgramCardsPhase
	{
		private IGame _game;
		
		public DealProgramCardsPhase(IGame game)
		{
			_game = game;
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
			foreach(var player in _game.Players)
			{
				int n = 0;
				while (n < 10)
				{
					player.Hand.AddCard(_game.CardDeck.TakeCard());
				}
			}
		}		
	}
}
