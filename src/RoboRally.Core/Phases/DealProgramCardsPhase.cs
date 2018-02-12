using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
	public class DealProgramCardsPhase : IDealProgramCardsPhase
	{
		private const int CardsPerPlayer = 9;

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
			foreach (var player in _game.Players)
			{
				for (var i = 0; i < CardsPerPlayer; i++)
				{
					player.Hand.Cards.Add(_game.CardDeck.TakeCard());
				}
			}
		}
	}
}
