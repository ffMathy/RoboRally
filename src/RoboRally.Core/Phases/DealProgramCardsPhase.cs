using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
	public class DealProgramCardsPhase : IDealProgramCardsPhase
	{
		public IGame Game => throw new NotImplementedException();

		public void Commit()
		{
			ShuffleDeck();
			DealCardsToPlayers();
		}

		private void ShuffleDeck()
		{
			Game.CardDeck.Shuffle();
		}

		private void DealCardsToPlayers()
		{
			foreach(var player in Game.Players)
			{
				int n = 0;
				while (n < 10)
				{
					player.Hand.AddCard(Game.CardDeck.TakeCard());
				}
			}
		}		
	}
}
